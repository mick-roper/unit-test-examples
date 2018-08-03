using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Fsa.DataSink
{
    public interface IRegionRequestFactory
    {
        HttpRequestMessage BuildRegionRequestMessage();
    }
}
