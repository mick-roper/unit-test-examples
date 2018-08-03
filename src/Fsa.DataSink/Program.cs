using System;
using System.Net.Http;

namespace Fsa.DataSink
{
    class Program
    {
        static readonly HttpClient httpClient = new HttpClient();

        static async void Main(string[] args)
        {
            IRegionService regionService = new RegionService(httpClient);

            var regions = await regionService.GetRegionsAsync();
        }
    }
}
