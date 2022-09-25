using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using System.Text;

namespace com.easypay.paymentapi.agents.Publishers
{
    public interface IMessageService
    {
        bool Enqueue(string queue, string message);
    }

    public class MessageService : IMessageService
    {
        ConnectionFactory _factory;
        IConnection _conn;
        IModel _channel;
        public MessageService(ILogger<MessageService> logger, IConfiguration config)
        {    
            logger.LogInformation("about to connect to rabbit");
            _factory = new ConnectionFactory() {
                Uri = new Uri(config.GetSection("ConnectionStringRabbitMQ").Value),
                NetworkRecoveryInterval = TimeSpan.FromSeconds(10),
                AutomaticRecoveryEnabled = true
            };
            _conn = _factory.CreateConnection();
            _channel = _conn.CreateModel();
            _channel.QueueDeclare(queue: "process-payment",
                        durable: false,
                        exclusive: false,
                        autoDelete: false,
                        arguments: null);
        }

        public bool Enqueue(string queue, string messageString)
        {
            var body = Encoding.UTF8.GetBytes(messageString);
            _channel.BasicPublish(exchange: "",
                                routingKey: queue,
                                basicProperties: null,
                                body: body);
            return true;
        }
    }
}