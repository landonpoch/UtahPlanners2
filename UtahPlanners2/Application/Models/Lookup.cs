using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UtahPlanners2.Application.Models
{
    public enum LookupType
    {
        Property,
        Street,
        SocioEcon
    }

    public class Lookup
    {
        public Guid Id { get; set; }
        public LookupType Type { get; set; }
        public string Description { get; set; }
    }
}