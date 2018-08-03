using System;
using System.Collections.Generic;
using System.Text;

namespace Fsa.DataSink.Models
{
    public sealed class Region
    {
        public Region(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; }
        public string Name { get; }

        public override string ToString()
        {
            return string.Concat(Id, ": ", Name);
        }
    }
}
