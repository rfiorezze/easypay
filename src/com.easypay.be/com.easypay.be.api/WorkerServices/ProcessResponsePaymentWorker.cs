using com.easypay.be.api.WorkerServices.Dtos;
using com.easypay.be.application.Payments.Commands;
using MediatR;
using MongoDB.Bson;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace com.easypay.api.WorkerService;

public class ProcessResponsePaymentWorker : BackgroundService
{
    private readonly ILogger<ProcessResponsePaymentWorker> _logger;
    private readonly IConfiguration _config;
    private readonly IMediator _mediator;

    public ProcessResponsePaymentWorker(ILogger<ProcessResponsePaymentWorker> logger,
        IConfiguration config,
        IMediator mediator)
    {
        _config = config;
        _logger = logger;
        logger.LogInformation($"Queue = process-response-payment");
        _mediator = mediator;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var factory = new ConnectionFactory()
        {
            Uri = new Uri(_config.GetSection("ConnectionStringRabbitMQ").Value)
        };
        using var connection = factory.CreateConnection();
        using var channel = connection.CreateModel();

        channel.QueueDeclare(queue: "process-response-payment",
                            durable: false,
                            exclusive: false,
                            autoDelete: false,
                            arguments: null);

        var consumer = new EventingBasicConsumer(channel);
        consumer.Received += Consumer_Received;
        channel.BasicConsume(queue: "process-response-payment",
            autoAck: true,
            consumer: consumer);

        while (!stoppingToken.IsCancellationRequested)
        {
            _logger.LogInformation(
                $"Worker ativo em: {DateTime.Now:yyyy-MM-dd HH:mm:ss}");
            await Task.Delay(TimeSpan.FromSeconds(10), stoppingToken);
        }
    }

    private void Consumer_Received(
        object sender, BasicDeliverEventArgs e)
    {
        _logger.LogInformation(
            $"[New Message | {DateTime.Now:yyyy-MM-dd HH:mm:ss}] " +
            Encoding.UTF8.GetString(e.Body.ToArray()));

        try
        {
            var message = Encoding.UTF8.GetString(e.Body.ToArray());
            var response = JsonConvert
            .DeserializeObject<ResponsePaymentDto>(message);

            var processResponsePaymentNotification = new ProcessResponsePaymentNotification(
                transactionId: response.TransactionId,
                isApproved: response.IsApproved,
                description: response.Description);

            _mediator.Publish(processResponsePaymentNotification);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
        }      
    }
}