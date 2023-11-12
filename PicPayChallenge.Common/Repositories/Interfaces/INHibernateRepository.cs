using PicPayChallenge.Common.Entities;
using PicPayChallenge.Common.Responses;

namespace PicPayChallenge.Common.Repositories.Interfaces
{
    public interface INHibernateRepository<T> where T : Entity
    {
        T Insert(T entity);
        T Get(int id);
        T Update(T entity);
        void Delete(T entity);
        IQueryable<T> Query();
        Pagination<T> ListPaginated(IQueryable<T> query, int itemsPerPage, int page);
        IEnumerable<T> List(IQueryable<T> query);
    }
}
