// See https://aka.ms/new-console-template for more information

namespace PolyTutorials.App
{
    internal class Program
    {
        static int counter = 0;
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
        static void SimulateOperation()
        {

            counter++;
            Console.WriteLine("Retried");
            //Simulate an operation that may throw an exception
            if (counter == 3)
            {
                counter = 0;
                Console.WriteLine("No Error");
            }
            else
            {
                throw new Exception("Simulation failure");
            }

        }
    }
}






