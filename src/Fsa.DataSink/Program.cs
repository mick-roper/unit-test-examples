using Fsa.DataSink.Factories;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Fsa.DataSink
{
    class Program
    {
        static readonly HttpClient httpClient = new HttpClient();

        static void Main(string[] args)
        {
            var rootUri = new Uri(args[1]);

            AsyncMain(rootUri).Wait();
        }

        private static async Task AsyncMain(Uri rootUri)
        {
            var requestFactory = new RequestFactory(rootUri);

            IRegionService regionService = new RegionService(httpClient, requestFactory);

            var regions = await regionService.GetRegionsAsync();

            foreach (var region in regions)
            {
                Console.WriteLine(region);
            }
        }
    }
}
