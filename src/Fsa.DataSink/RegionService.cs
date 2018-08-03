using Fsa.DataSink.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Fsa.DataSink
{
    public sealed class RegionService : IRegionService
    {
        readonly HttpClient httpClient;
        readonly IRegionRequestFactory regionRequestFactory;

        readonly CancellationToken cancellationToken = default(CancellationToken);

        public RegionService(HttpClient httpClient, IRegionRequestFactory regionRequestFactory)
        {
            this.httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            this.regionRequestFactory = regionRequestFactory ?? throw new ArgumentNullException(nameof(regionRequestFactory));
        }

        public async Task<IEnumerable<Region>> GetRegionsAsync()
        {
            var req = regionRequestFactory.BuildRegionRequestMessage();

            using (var res = await httpClient.SendAsync(req, cancellationToken).ConfigureAwait(false))
            {
                var payload = await res.Content.ReadAsStringAsync().ConfigureAwait(false);

                return JsonConvert.DeserializeObject<IEnumerable<Region>>(payload);
            }
        }
    }
}
