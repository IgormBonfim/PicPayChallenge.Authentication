using PicPayChallenge.Authentication.Domain.Users.Entities;
using PicPayChallenge.Common.Repositories.Interfaces;

namespace PicPayChallenge.Authentication.Domain.Users.Repositories
{
    public interface IUsersRepository : INHibernateRepository<User>
    {
    }
}
