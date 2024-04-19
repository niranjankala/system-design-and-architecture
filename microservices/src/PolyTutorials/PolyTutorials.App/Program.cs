// See https://aka.ms/new-console-template for more information

using Polly;

namespace PolyTutorials.App
{
    internal class Program
    {
        static int counter = 0;
        static void Main(string[] args)
        {
            //Retry
            //var retryPolicy = Policy
            //                    .Handle<Exception>()
            //                    .WaitAndRetry(5, x => TimeSpan.FromSeconds(5));
            //retryPolicy.Execute(() => SimulateOperation());


            //Circuit Breaker
            //int count = 0;
            //var myPolicy = Policy
            //                    .Handle<Exception>()
            //                    .CircuitBreaker(5, TimeSpan.FromSeconds(10));

            //while (true)
            //{
            //    count++;
            //    Console.WriteLine($"Attempting{count}");
            //    try
            //    {
            //        myPolicy.Execute(() => SimulateOperationCircuitBreaker());
            //    }
            //    catch (Exception e)
            //    {
            //        Console.WriteLine(e.Message);
            //    }
            //    Thread.Sleep(1000);
            //}

            //Fallback

            //var myPolicy = Policy
            //                    .Handle<Exception>()
            //                    .Fallback(() => SimulateOperationRedundant());
            //myPolicy.Execute(() => SimulateOperation());


            //Exponential back off
            var policy = Policy
                .Handle<Exception>()
                .WaitAndRetry(5, x => TimeSpan.FromSeconds(
                    Math.Pow(2, x))
                , onRetry: (exception, timespan, context) =>
                {
                    Console.WriteLine($"Retrying after {timespan.TotalSeconds} seconds due to {exception.Message}");
                });

            policy.Execute(() => SimulateOperation());

            Console.ReadLine(); 
        }

        private static void SimulateOperationRedundant()
        {
            Console.WriteLine("No error from redundant");
        }
        static void SimulateOperationCircuitBreaker()
        {
            counter++;
            // Simulate an operation that may throw an exception
            if (counter == 4)
            {
                counter = 0;
                Console.WriteLine("No error");
            }
            else
            {
                throw new Exception("Simulated failure.");
            }
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






