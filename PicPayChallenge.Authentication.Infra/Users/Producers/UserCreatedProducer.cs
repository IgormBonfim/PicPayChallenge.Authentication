using Microsoft.Extensions.Configuration;
using PicPayChallenge.Authentication.DataTransfer.Users.Facts;
using PicPayChallenge.Authentication.Domain.Users.Producers;
using PicPayChallenge.Common.Producers;

namespace PicPayChallenge.Authentication.Infra.Users.Producers
{
    public class UserCreatedProducer : Producer<UserCreatedFact>, IUserCreatedProducer
    {
        public UserCreatedProducer(IConfiguration configuration) : base(configuration, "userCreated")
        {
        }
    }
}
