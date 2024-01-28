using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;
using TicketingSystem.Domain.Interfaces.Services;

namespace TicketingSystem.Services
{
    public class MessageProducer : IMessageProducer
    {
        public void SendMessage<T>(T message)
        {
            var factory = new ConnectionFactory()
            {
                HostName = "localhost"
            };
            factory.Uri = new Uri("amqp://guest:guest@localhost:5672");
            var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();
            channel.QueueDeclare("email_notification");

            var json = JsonConvert.SerializeObject(message);
            var body = Encoding.UTF8.GetBytes(json);

            channel.BasicPublish(exchange: "", routingKey: "email_notifications", body: body);
        }
    }
}
