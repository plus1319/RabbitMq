using System;
using System.Text;
using RabbitMQ.Client;

namespace Producer
{
    class Sender
    {
        static void Main(string[] args)
        {
            var factory = new ConnectionFactory() {HostName = "localhost"};
            using (var connection = factory.CreateConnection())
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare("BasicTest", false, false, false, null);

                    string publishMessage = "Getting started with .net core";
                    byte[] body = Encoding.UTF8.GetBytes(publishMessage);
                        
                    channel.BasicPublish("","BasicTest",null,body);
                    Console.WriteLine($"Sending {publishMessage}");
                }

            Console.ReadKey();
        }
    }
}
