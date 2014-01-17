using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using UtahPlanners2.Application;
using UtahPlanners2.Application.Models.Commands;
using UtahPlanners2.Application.Models.Queries;
using UtahPlanners2.Domain.Contract;

namespace UtahPlanners2.Controllers
{
    public class LookupController : ApiController
    {
        private ApplicationMapper _mapper;
        private IPersistentRepository<Domain.Lookup> _lookupRepo;


        public LookupController()
        {
            _mapper = new ApplicationMapper(); // TODO: Wire up DI
            _lookupRepo = null; // TODO: Initialize with DI
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

        public bool Put(CreateLookup lookup)
        {
            bool success = false;
            try
            {
                var type = _mapper.Convert(lookup.Type);
                var entity = new Domain.Lookup(type, lookup.Description);
                _lookupRepo.Create(entity);
                success = true;
            }
            catch (Exception e)
            {
                // TODO: Logging
            }
            return success;
        }
    }
}