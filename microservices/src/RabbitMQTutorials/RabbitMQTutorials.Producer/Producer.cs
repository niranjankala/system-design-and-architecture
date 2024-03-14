using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQTutorials.Producer
{
    internal class Producer
    {
        public void Provide(string queue, object obj)
        {            
            //Create Connection 
            Uri uri = new Uri("amqp://guest:guest@localhost:5672");
            ConnectionFactory factory = new ConnectionFactory() { Uri = uri };            
            IConnection connection = factory.CreateConnection();

            //Create channel
            IModel channel = connection.CreateModel();

            //Declare a Queue ==> Create a queue only if it doesn't already exist.
            //channel.QueueDeclare(queue,
            //    durable: true,
            //    exclusive:false,
            //    autoDelete:false,
            //    arguments:null);

            //durable: true --> hand around there until a consumer reads it
            string messageObject = JsonConvert.SerializeObject(obj);
            Console.WriteLine($"Sending : {messageObject}");

            //message content is a byte array
            byte[] messageBody = Encoding.UTF8.GetBytes(messageObject);

            channel.BasicPublish(
                exchange:"HospitalExchange", 
                routingKey:"Doctor", 
                basicProperties:null, 
                body: messageBody);
        }
    }
}
