using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UtahPlanners2.Application.Models.Queries;

namespace UtahPlanners2.Application.Models.Commands
{
    public class CreateLookup
    {
        public LookupType Type { get; set; }
        public string Description { get; set; }
    }
}