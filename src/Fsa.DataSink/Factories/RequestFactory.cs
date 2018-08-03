using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Fsa.DataSink.Factories
{
    public sealed class RequestFactory : IRegionRequestFactory
    {
        readonly Uri apiRoot;

        public RequestFactory(Uri apiRoot)
        {
            this.apiRoot = apiRoot ?? throw new ArgumentNullException(nameof(apiRoot));
        }

        public HttpRequestMessage BuildRegionRequestMessage()
        {
            var uri = BuildUriWithPath("region");

            var req = new HttpRequestMessage(HttpMethod.Get, uri);

            req.Headers.Add("x-api-version", "2");

            return req;
        }

        private Uri BuildUriWithPath(string path)
        {
            var builder = new UriBuilder(apiRoot);

            builder.Path = path;

            return builder.Uri;
        }
    }
}
