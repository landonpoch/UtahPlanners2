using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UtahPlanners2.Domain;
using UtahPlanners2.Domain.Contract;

namespace UtahPlanners2.Infrastructure
{
    public class MongoPersistentRepository<T> : IPersistentRepository<T>
        where T : Aggregate
    {
        private const string MongoDbName = "UtahPlanners2";

        private MongoCollection<T> Collection { get; set; }

        public MongoPersistentRepository()
        {
            Collection = new MongoClient()
                .GetServer()
                .GetDatabase(MongoDbName)
                .GetCollection<T>(typeof(T).Name);
        }

        public T Get(Guid id)
        {
            return Collection.FindOneById(id);
        }

        public List<T> FindAll()
        {
            return Collection.FindAll()
                .ToList();
        }

        public List<T> Find(Func<T, bool> predicate)
        {
            return Collection.AsQueryable()
                .Where(predicate)
                .ToList();
        }

        public bool Save(T aggregate)
        {
            bool success = false;
            var existingAggregate = Get(aggregate.Id);
            
            if (existingAggregate != null)
            {
                if (existingAggregate.Version == aggregate.Version)
                {
                    // Update
                    IncrementConcurrencyVersion(aggregate);
                    success = Collection.Update(Query<T>.EQ(a => a.Id, aggregate.Id), Update<T>.Replace(aggregate)).Ok;
                }
                else
                {
                    // optimistic concurrency exception
                    // TODO: Figure out how to handle this in an eventually consistent way with the UI
                }
            }
            else
            {
                // Insert
                success = Collection.Insert(aggregate).Ok;
            }

            return success;
        }

        public bool Delete(Guid id)
        {
            var result = Collection.Remove(Query<T>.EQ(a => a.Id, id));
            return result.Ok;
        }

        private void IncrementConcurrencyVersion(Aggregate a)
        {
            var version = a.Version + 1;
            typeof(Aggregate).GetProperty("Version")
                    .SetValue(a, version);
        }
    }
}