using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using UtahPlanners2.Application;
using UtahPlanners2.Application.Models;
using UtahPlanners2.Domain.Contract;
using UtahPlanners2.Infrastructure; // TODO: Initialize with DI

namespace UtahPlanners2.Controllers
{
    public abstract class BaseController : ApiController
    {
        protected ApplicationMapper _mapper;
        protected IPersistentRepository<Domain.Lookup> _lookupRepo;

        public BaseController()
        {
            _mapper = new ApplicationMapper(); // TODO: Wire up DI
            _lookupRepo = new MongoPersistentRepository<Domain.Lookup>(); // TODO: Initialize with DI
        }

        protected bool ExecuteUnsafeOperation<T>(T resource, Func<T, bool> operation)
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

    public class LookupController : BaseController
    {
        public Lookup Get(string id)
        {
            var lookup = _lookupRepo.Get(new Guid(id));
            return _mapper.Convert(lookup);
        }

        public IEnumerable<Lookup> Get()
        {
            var lookups = _lookupRepo.FindAll();
            return _mapper.Convert(lookups);
        }

        public void Put(Lookup lookup)
        {
            // TODO: this should run as an async task so that it is non-blocking
            UpdateLookup(lookup);
        }

        public void Patch(Lookup lookup)
        {
            // TODO: this should run as an async task so that it is non-blocking
            UpdateLookup(lookup);
        }

        public void Delete(Lookup lookup)
        {
            // TODO: this should run as an async task so that it is non-blocking
            ExecuteUnsafeOperation(lookup, (l) =>
            {
                var lookupType = _mapper.Convert(l.Type);
                return _lookupRepo.Delete(l.Id);
            });
        }

        private bool UpdateLookup(Lookup lookup)
        {
            return ExecuteUnsafeOperation(lookup, (l) =>
            {
                var lookupType = _mapper.Convert(l.Type);
                return _lookupRepo.Save(new Domain.Lookup(l.Id, lookupType, l.Description));
            });
        }
    }
}