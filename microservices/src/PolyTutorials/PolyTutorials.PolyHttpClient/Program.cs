
using Polly;

namespace PolyTutorials.PolyHttpClient
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //PostIt();
            //PostItHandleResponseMessageAsync();
            PostItHandleRequestMessageAsync();
            Console.ReadLine();
        }

        private static async void PostItHandleResponseMessageAsync()
        {
            HttpClient httpClient = new HttpClient();
            var policyBuilder = Policy
                .HandleResult<HttpResponseMessage>(message => !message.IsSuccessStatusCode)
                .WaitAndRetryAsync(new[]
                {
                    TimeSpan.FromSeconds(5),
                    TimeSpan.FromSeconds(7),
                    TimeSpan.FromSeconds(10)
                }, (result, timeSpan, retryCount, context) => {
                    Console.WriteLine($"Request failed with {result.Result.StatusCode}. Retry count = {retryCount}. Waiting {timeSpan} before next retry. ");
                });
            var response = await policyBuilder
                .ExecuteAsync(() => httpClient.GetAsync("https://localhost:7061/values"));
        }


        private static async void PostItHandleRequestMessageAsync()
        {
            var httpClient = new HttpClient();
            var policy = Policy
                .Handle<HttpRequestException>()
                .WaitAndRetryAsync(3, x => TimeSpan.FromSeconds(10),
                (exception, retryCount) => {
                    Console.WriteLine($"Request failed with {exception.Message}. " +
                        $" Retry count = {retryCount}. ");
                });
            var response = await policy.ExecuteAsync(() =>
            httpClient.GetAsync("https://localhost:7061/values"));
            if (response.IsSuccessStatusCode)
                Console.WriteLine("Response was successful with 200");
            else
                Console.WriteLine($"Response failed. Status code {response.StatusCode}");
        }

        static async void PostIt()
        {
            var httpClient = new HttpClient();
            //call the httpbin service
            var response = await httpClient.GetAsync("https://localhost:7061/values");
            if (response.IsSuccessStatusCode)
                Console.WriteLine("Response was successful with 200");
            else
                Console.WriteLine($"Response failed. Status code {response.StatusCode}");
        }    
}
}
