// See https://aka.ms/new-console-template for more information
using Newtonsoft.Json;
using RabbitMQTutorials.Models;
using System;
using System.Timers;

namespace RabbitMQTutorials.Consumer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Consumer consumer = new Consumer();
            consumer.MessageReceived += (sender, message) =>
            {
                Patient receivedData = JsonConvert.DeserializeObject<Patient>(message);
                Console.WriteLine("Message Received: {0}",message);
            };
            consumer.Consume();

            Console.ReadKey();  

        }

    }
}
