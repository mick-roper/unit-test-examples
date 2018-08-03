using System;
using System.Net.Http;

namespace Fsa.DataSink
{
    class Program
    {
        static readonly HttpClient httpClient = new HttpClient();
        static readonly Uri apiRoot = new Uri("");

        static async void Main(string[] args)
        {
            IRegionService regionService = new RegionService(httpClient, apiRoot);

            var regions = await regionService.GetRegionsAsync();

            foreach (var region in regions)
            {
                Console.WriteLine(region);
            }
        }
    }
}
