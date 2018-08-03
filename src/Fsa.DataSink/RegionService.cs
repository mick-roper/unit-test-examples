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
        readonly Uri rootUri;
        readonly HttpClient httpClient;

        public RegionService(HttpClient httpClient, Uri rootUri)
        {
            this.httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            this.rootUri = rootUri ?? throw new ArgumentNullException(nameof(rootUri));
        }

        public Task<IEnumerable<Region>> GetRegionsAsync()
        {
            throw new NotImplementedException();
        }
    }
}
