using Moq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Xunit;

namespace Fsa.DataSink.Tests
{
    public class RegionServiceTests
    {
        readonly Mock<HttpClient> mockHttpClient = new Mock<HttpClient>();
        readonly Uri uri = new Uri("http://tempuri.org");

        [Fact]
        public void ctor_throws_exception_if_httpClient_is_null()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => new RegionService(null, uri));

            Assert.Equal("httpClient", ex.ParamName);
        }

        [Fact]
        public void ctor_throws_exception_if_uri_is_null()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => new RegionService(mockHttpClient.Object, null));

            Assert.Equal("rootUri", ex.ParamName);
        }
    }
}
