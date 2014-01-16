using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using UtahPlanners2.Application;
using UtahPlanners2.Application.Models.Queries;

namespace UtahPlanners2.Controllers
{
    public class LookupController : ApiController
    {
        private ApplicationMapper _mapper;

        public LookupController()
        {
            _mapper = new ApplicationMapper(); // TODO: Wire up DI
        }

        public Lookup Get(string id)
        {
            return new Lookup
            {
                Id = Guid.NewGuid(),
                Type = LookupType.Property,
                Description = "Stacked Flats"
            };
        }

        public bool Put(Lookup lookup)
        {
            return true;
        }
    }
}