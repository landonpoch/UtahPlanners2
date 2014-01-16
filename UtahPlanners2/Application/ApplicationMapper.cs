using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UtahPlanners2.Application.Models.Queries;

namespace UtahPlanners2.Application
{
    public class ApplicationMapper
    {
        #region Queries

        public Lookup Convert(Domain.Lookup l)
        {
            return new Lookup
            {
                Id = l.Id,
                Type = Convert(l.Type),
                Description = l.Description
            };
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

        #endregion

        #region Commands

        #endregion
    }
}