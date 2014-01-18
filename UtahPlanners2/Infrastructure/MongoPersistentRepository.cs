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
            if (aggregate.Id == Guid.Empty)
            {
                success = Collection.Insert(aggregate).Ok;
            }
            else
            {
                IncrementConcurrencyVersion(aggregate);
                var optimisticConcurrencyQuery = Query.And(
                    Query<T>.EQ(a => a.Id, aggregate.Id),
                    Query<T>.EQ(a => a.Version, aggregate.Version - 1)
                );

                success = Collection.Update(optimisticConcurrencyQuery, Update<T>.Replace(aggregate)).Ok;
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