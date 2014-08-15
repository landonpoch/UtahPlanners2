using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UtahPlanners2.Application.Models;

namespace UtahPlanners2.Application
{
    public class ApplicationMapper
    {
        public Lookup Convert(Domain.Lookup l)
        {
            return new Lookup
            {
                Id = l.Id,
                ETag = l.Version,
                Type = Convert(l.Type),
                Description = l.Description
            };
        }

        public List<Lookup> Convert(List<Domain.Lookup> items)
        {
            var lookups = new List<Lookup>();
            foreach (var item in items)
                lookups.Add(Convert(item));
            return lookups;
        }

        public Domain.LookupType Convert(LookupType lt)
        {
            switch (lt)
            {
                case LookupType.Property:
                    return Domain.LookupType.Property;
                case LookupType.Street:
                    return Domain.LookupType.Street;
                case LookupType.SocioEcon:
                    return Domain.LookupType.SocioEcon;
            }
            throw new Exception("Could not map LookupType to Domain.LookupType");
        }

        private LookupType Convert(Domain.LookupType lt)
        {
            switch (lt)
            {
                case Domain.LookupType.Property:
                    return LookupType.Property;
                case Domain.LookupType.Street:
                    return LookupType.Street;
                case Domain.LookupType.SocioEcon:
                    return LookupType.SocioEcon;
            }
            throw new Exception("Could not map Domain.LookupType to Application.LookupType");
        }
    }
}