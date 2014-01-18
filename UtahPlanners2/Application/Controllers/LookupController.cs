using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using UtahPlanners2.Application;
using UtahPlanners2.Application.Models.Commands;
using UtahPlanners2.Application.Models.Queries;
using UtahPlanners2.Domain.Contract;
using UtahPlanners2.Infrastructure; // TODO: Initialize with DI

namespace UtahPlanners2.Controllers
{
    public class LookupController : ApiController
    {
        private ApplicationMapper _mapper;
        private IPersistentRepository<Domain.Lookup> _lookupRepo;

        public LookupController()
        {
            _mapper = new ApplicationMapper(); // TODO: Wire up DI
            _lookupRepo = new MongoPersistentRepository<Domain.Lookup>(); // TODO: Initialize with DI
        }

        public Lookup Get(string id)
        {
            var lookup = _lookupRepo.Get(new Guid(id));
            return _mapper.Convert(lookup);
        }

        //public CreateLookup GetCreateLookup(string id)
        //{
        //    return new CreateLookup
        //    {
        //        Type = LookupType.Property,
        //        Description = "Stacked Flats"
        //    };
        //}

        public IEnumerable<Lookup> Get()
        {
            var lookups = _lookupRepo.FindAll();
            return _mapper.Convert(lookups);
        }

        public bool PutCreateLookup([FromBody]CreateLookup createLookup)
        {
            return ExecuteUnsafeOperation(createLookup, (resource) =>
            {
                var lookupType = _mapper.Convert(resource.Type);
                var lookup = new Domain.Lookup(lookupType, resource.Description);
                return _lookupRepo.Save(lookup);
            });
        }

        public bool Post(RenameLookup renameLookup)
        {
            return ExecuteUnsafeOperation(renameLookup, (resource) =>
            {
                var lookup = _lookupRepo.Get(resource.Id);
                lookup.Rename(resource.Name);
                return _lookupRepo.Save(lookup);
            });
        }

        private bool ExecuteUnsafeOperation<T>(T resource, Func<T, bool> operation)
        {
            bool success = false;
            try
            {
                success = operation(resource);
            }
            catch (Exception e)
            {
                // TODO: Logging
            }
            return success;
        }
    }
}