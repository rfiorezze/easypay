using com.easypay.paymentapi.agents.Publishers;
using com.easypay.paymentapi.agents.Publishers.Dtos;
using com.easypay.paymentapi.api.WorkerServices.Dtos;
using com.easypay.paymentapi.application.Payments.Commands;
using MediatR;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace com.easypay.paymentapi.api.WorkerServices;

public class ProcessPaymentWorker : BackgroundService
{
    private readonly ILogger<ProcessPaymentWorker> _logger;
    private readonly IConfiguration _config;
    private readonly IMediator _mediator;
    private readonly IMessageService _messageService;

    public ProcessPaymentWorker(ILogger<ProcessPaymentWorker> logger,
        IConfiguration config,
        IMediator mediator,
        IMessageService messageService)
    {
        _config = config;
        _logger = logger;
        logger.LogInformation($"Queue = process-payment");
        _mediator = mediator;
        _messageService = messageService;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var factory = new ConnectionFactory()
        {
            Uri = new Uri(_config.GetSection("ConnectionStringRabbitMQ").Value)
        };
        using var connection = factory.CreateConnection();
        using var channel = connection.CreateModel();

        channel.QueueDeclare(queue: "process-payment",
                            durable: false,
                            exclusive: false,
                            autoDelete: false,
                            arguments: null);

        var consumer = new EventingBasicConsumer(channel);
        consumer.Received += Consumer_Received;
        channel.BasicConsume(queue: "process-payment",
            autoAck: true,
            consumer: consumer);

        while (!stoppingToken.IsCancellationRequested)
        {
            _logger.LogInformation(
                $"Worker Process Payment active in: {DateTime.Now:yyyy-MM-dd HH:mm:ss}");
            await Task.Delay(TimeSpan.FromSeconds(10), stoppingToken);
        }
    }

    private async void Consumer_Received(
        object sender, BasicDeliverEventArgs e)
    {
        try
        {
            var messageEncoding = Encoding.UTF8.GetString(e.Body.ToArray());
            var message = JsonConvert
            .DeserializeObject<ProcessPaymentDto>(messageEncoding);

            var processPaymentRequest = new ProcessPaymentCommandRequest(
                transactionId: message.TransactionId,
                cardNumber: message.CardNumber,
                dueDate: message.DueDate,
                cardHolderName: message.CardHolderName,
                securityCode: message.SecurityCode,
                cpfHolder: message.CpfHolder,
                address: message.Address,
                ammount: message.Ammount,
                clientId: message.ClientId,
                transactionDate: message.TransactionDate);

            var response = await _mediator.Send(processPaymentRequest);

            var responsePayment = new ResponsePaymentDto(
                transactionId: processPaymentRequest.TransactionId,
                isApproved: response.IsApproved,
                description: response.Description);

            _messageService.Enqueue("process-response-payment", JsonConvert.SerializeObject(responsePayment));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
        }      
    }
}