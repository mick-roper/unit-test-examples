using Fsa.DataSink.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Fsa.DataSink
{
    public sealed class RegionService : IRegionService
    {
        readonly HttpClient httpClient;

        public RegionService(HttpClient httpClient)
        {
            this.httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public Task<IEnumerable<Region>> GetRegionsAsync()
        {
            throw new NotImplementedException();
        }
    }
}
