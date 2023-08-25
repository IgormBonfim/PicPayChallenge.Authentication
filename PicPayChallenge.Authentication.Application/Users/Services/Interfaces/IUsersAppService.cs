using PicPayChallenge.Authentication.DataTransfer.Users.Requests;

namespace PicPayChallenge.Authentication.Application.Users.Services.Interfaces
{
    public interface IUsersAppService
    {
        void RegisterUser(UserRegisterRequest request);
        void AuthUser(UserAuthRequest request);
    }
}
