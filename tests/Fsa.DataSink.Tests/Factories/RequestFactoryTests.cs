using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using Xunit;

namespace Fsa.DataSink.Factories.Tests
{
    public class RequestFactoryTests
    {
        [Fact]
        public void ctor_throws_exception_if_arg_is_null()
        {
            Uri uri = null;

            var ex = Assert.Throws<ArgumentNullException>(() => new RequestFactory(uri));

            Assert.Equal("apiRoot", ex.ParamName);
        }

        [Fact]
        public void BuildRegionRequestMessage_returns_a_properly_configured_object()
        {
            const string ADDRESS = "http://tempuri.org";

            var inputUri = new Uri(ADDRESS);

            var component = new RequestFactory(inputUri);

            var actual = component.BuildRegionRequestMessage();

            var expectedUri = new Uri(ADDRESS + "/region");

            Assert.Equal(expectedUri, actual.RequestUri);
            Assert.Equal(HttpMethod.Get, actual.Method);
            Assert.Equal("2", string.Concat(actual.Headers.GetValues("x-api-version")));
        }
    }
}
