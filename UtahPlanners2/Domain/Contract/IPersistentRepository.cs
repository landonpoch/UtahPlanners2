using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UtahPlanners2.Domain.Contract
{
    public interface IPersistentRepository<T>
        where T : Aggregate
    {
        T Get(Guid id);
        List<T> Find(Func<T, bool> predicate);

        T Create(T aggregate);
        T Update(Guid id, T aggregate);
        bool Delete(Guid id);
    }
}