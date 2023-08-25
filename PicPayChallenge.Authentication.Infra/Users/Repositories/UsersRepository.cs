using NHibernate;
using PicPayChallenge.Authentication.Domain.Users.Entities;
using PicPayChallenge.Authentication.Domain.Users.Repositories;
using PicPayChallenge.Common.Repositories;

namespace PicPayChallenge.Authentication.Infra.Users.Repositories
{
    public class UsersRepository : NHibernateRepository<User>, IUsersRepository
    {
        public UsersRepository(ISession session) : base(session) { }
    }
}
