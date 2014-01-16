using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UtahPlanners2.Application.Models.Commands
{
    public class CreateWeightedLookup : CreateLookup
    {
        public int Weight { get; set; }
    }
}