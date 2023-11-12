using PicPayChallenge.Authentication.Domain.Users.Entities;
using PicPayChallenge.Authentication.Domain.Users.Services.Commands;

namespace PicPayChallenge.Authentication.Domain.Users.Services.Interfaces
{
    public interface IUsersService
    {
        User Instance(UserInstanceCommand command);
        User RegisterUser(User user);
        User AuthUser(UserAuthCommand command);
        User Validate(int id);
        string GenerateToken(User user);
    }
}
