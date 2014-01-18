using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UtahPlanners2.Application.Models.Commands
{
    public class RenameLookup
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}