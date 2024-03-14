using RabbitMQTutorials.Models;
using System.Timers;

namespace RabbitMQTutorials.Producer
{
    internal class Program
    {
       
        static void Main(string[] args)
        {
            Console.WriteLine("Hi this is Producer!!!");
            string option = "Y";
            Producer producer = new Producer(); 
            do
            {
                Console.WriteLine($"{Environment.NewLine}Please enter patient name:");
                string patientName = Console.ReadLine();
                Patient patient = new Patient();
                patient.Name = patientName;
                producer.Provide("Patient", patient);
                Console.WriteLine("Do you want to continue (Y/N):");
                option = Console.ReadKey().KeyChar.ToString();
            } while (option == "Y" || option == "y");
        }        
    }
}
