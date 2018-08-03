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
        readonly IRegionRequestFactory regionRequestFactory;

        public RegionService(HttpClient httpClient, IRegionRequestFactory regionRequestFactory)
        {
            this.httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            this.regionRequestFactory = regionRequestFactory ?? throw new ArgumentNullException(nameof(regionRequestFactory));
        }

        public Task<IEnumerable<Region>> GetRegionsAsync()
        {
            throw new NotImplementedException();
        }
    }
}
