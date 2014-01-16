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
        public Lookup(LookupType type, string description)
        {
            Type = type;
            Description = description;
        }

        public LookupType Type { get; private set; }

        public string Description { get; private set; }
    }

    public class WeightedLookup : Lookup
    {
        public WeightedLookup(LookupType type, string description, int weight)
            :base(type, description)
        {
            Weight = weight;
        }

        public int Weight { get; private set; }
    }
}