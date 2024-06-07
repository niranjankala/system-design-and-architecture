using EventSourcingTutorials.App.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EventSourcingTutorials.App.Data
{
    public abstract class EfCommon<T> : DbContext, IRepository<T>
            where T : class
    {
        public bool Add(T obj)
        {
            Set<T>().Add(obj);
            return true;
        }

        public List<T> Query(int it)
        {
            throw new NotImplementedException();
        }

        public List<T> Query(string name)
        {
            throw new NotImplementedException();
        }

        public bool Update(T obj)
        {
            throw new NotImplementedException();
        }
    }
}
