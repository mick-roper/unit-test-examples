﻿using System;
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

        public override string ToString() => string.Concat(Id, ": ", Name);

        public override bool Equals(object obj) => obj as Region != null ? obj.GetHashCode() == GetHashCode() : false;

        public override int GetHashCode()
        {
            const int PRIME = 8581;
            int hash = PRIME;

            unchecked
            {
                hash = (Id * PRIME) + hash;
                hash = (Name?.GetHashCode() ?? 1 * PRIME) + hash;
            }

            return hash;
        }
    }
}
