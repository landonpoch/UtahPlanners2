using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UtahPlanners2.Domain
{
    public abstract class Aggregate
    {
        public Guid Id { get; private set; }

        public int Version { get; private set; }

        protected Aggregate(Guid id, int version)
        {
            Id = id;
            Version = version;
        }
    }
}