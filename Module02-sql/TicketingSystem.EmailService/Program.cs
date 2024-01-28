﻿using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace TicketingSystem.EmailService
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            var factory = new ConnectionFactory()
            {
                HostName = "localhost"
            };
            var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();

            channel.QueueDeclare("email_notifications");

            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (model, eventArgs) =>
            {
                var body = eventArgs.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);

                Console.WriteLine(message);
            };

            channel.BasicConsume(queue: "email_notifications", autoAck: true, consumer: consumer);
            Console.ReadKey();
        }
    }
}
