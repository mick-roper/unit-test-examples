using Fsa.DataSink.Factories;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Fsa.DataSink
{
    class Program
    {
        static readonly HttpClient httpClient = new HttpClient();
        static readonly Uri apiRoot = new Uri("");

        static void Main(string[] args)
        {
            AsyncMain().Wait();
        }

        private static async Task AsyncMain()
        {
            var requestFactory = new RequestFactory(apiRoot);

            IRegionService regionService = new RegionService(httpClient, requestFactory);

            var regions = await regionService.GetRegionsAsync();

            foreach (var region in regions)
            {
                Console.WriteLine(region);
            }
        }
    }
}
