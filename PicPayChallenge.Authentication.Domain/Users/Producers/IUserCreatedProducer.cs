using PicPayChallenge.Authentication.DataTransfer.Users.Facts;
using PicPayChallenge.Common.Producers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicPayChallenge.Authentication.Domain.Users.Producers
{
    public interface IUserCreatedProducer : IProducer<UserCreatedFact>
    {
    }
}
