using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitMQTutorials.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQTutorials.Consumer
{
    internal class Consumer
    {
        public EventHandler<string> MessageReceived; 
        public void Consume()
        {
            Console.WriteLine("Hi this is Consumer!!!");
            //Create Connection 
            Uri uri = new Uri("amqp://guest:guest@localhost:5672");
            ConnectionFactory factory = new ConnectionFactory();
            factory.Uri = uri; 

            IConnection connection = factory.CreateConnection();
            IModel channel = connection.CreateModel();

            //Declare a Queue ==> Create a queue only if it doesn't already exist. 
            //channel.QueueDeclare("DoctorQueue", 
            //    durable: true,
            //    exclusive: false,
            //    autoDelete: false,
            //    arguments: null
            //   );

            //durable: true --> hand around there until a consumer reads it

            //consumer
            var consumer = new EventingBasicConsumer( channel );
            consumer.Received += (sender, e) =>
            {
                var body = e.Body.ToArray();    
                var message = Encoding.UTF8.GetString( body );

                if (MessageReceived != null)
                {
                    MessageReceived(this, message);
                }
            };

            channel.BasicConsume(
                queue: "DoctorQueue",
                autoAck: true,
                consumer: consumer);

        }
    }
}
