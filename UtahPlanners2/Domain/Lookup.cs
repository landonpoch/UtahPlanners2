using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UtahPlanners2.Domain
{
    public enum LookupType
    {
        Property,
        Street,
        SocioEcon
    }

    public class Lookup : Aggregate
    {
        public Lookup(Guid id, int version, LookupType type, string description)
            :base(id, version)
        {
            Type = type;
            Description = description;
        }

        public LookupType Type { get; private set; }

        public string Description { get; private set; }

        public void Rename(string name)
        {
            Description = name;
        }
    }

    public class WeightedLookup : Lookup
    {
        public WeightedLookup(Guid id, int version, LookupType type, string description, int weight)
            :base(id, version, type, description)
        {
            Weight = weight;
        }

        public int Weight { get; private set; }
    }
}