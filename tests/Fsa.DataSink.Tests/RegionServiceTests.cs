using Fsa.DataSink.Models;
using Moq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Fsa.DataSink.Tests
{
    public class RegionServiceTests
    {
        readonly Mock<HttpClient> mockHttpClient = new Mock<HttpClient>();
        readonly Mock<IRegionRequestFactory> mockRequestFactory = new Mock<IRegionRequestFactory>();

        [Fact]
        public void ctor_throws_exception_if_httpClient_is_null()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => new RegionService(null, mockRequestFactory.Object));

            Assert.Equal("httpClient", ex.ParamName);
        }

        [Fact]
        public void ctor_throws_exception_if_requestFactory_is_null()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => new RegionService(mockHttpClient.Object, null));

            Assert.Equal("regionRequestFactory", ex.ParamName);
        }

        [Fact]
        public async Task GetRegionAsync_returns_expected_response()
        {
            var inputData = new[] { new Region(1, "A"), new Region(2, "B"), new Region(3, "C") };

            var mockReponse = new Mock<HttpResponseMessage>();
            mockReponse
                .Setup(x => x.Content)
                .Returns(new StringContent(JsonConvert.SerializeObject(inputData), Encoding.UTF8, "application/json"));

            var request = Mock.Of<HttpRequestMessage>();

            mockRequestFactory
                .Setup(x => x.BuildRegionRequestMessage())
                .Returns(request);

            mockHttpClient
                .Setup(x => x.SendAsync(request, CancellationToken.None))
                .ReturnsAsync(mockReponse.Object);

            var component = new RegionService(mockHttpClient.Object, mockRequestFactory.Object);

            var outputData = await component.GetRegionsAsync();

            Assert.Equal(inputData.Length, outputData.Count());

            foreach (var item in inputData)
            {
                Assert.Contains(item, outputData);
            }
        }
    }
}
