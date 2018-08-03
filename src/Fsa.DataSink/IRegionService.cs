using Fsa.DataSink.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Fsa.DataSink
{
    public interface IRegionService
    {
        Task<IEnumerable<Region>> GetRegionsAsync();
    }
}
