using PicPayChallenge.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace PicPayChallenge.Common.Repositories.Interfaces
{
    public interface INHibernateRepository<T> where T : Entity
    {
        T Insert(T entity);
        T Get(int id);
        T Update(T entity);
        void Delete(T entity);
        IQueryable<T> Query();
    }
}
