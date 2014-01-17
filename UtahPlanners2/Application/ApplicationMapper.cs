using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UtahPlanners2.Application.Models.Queries;

namespace UtahPlanners2.Application
{
    public class ApplicationMapper
    {
        public Lookup Convert(Domain.Lookup l)
        {
            return new Lookup
            {
                Id = l.Id,
                Type = Convert(l.Type),
                Description = l.Description
            };
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