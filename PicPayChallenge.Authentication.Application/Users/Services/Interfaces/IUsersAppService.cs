using PicPayChallenge.Authentication.DataTransfer.Users.Requests;
using PicPayChallenge.Authentication.DataTransfer.Users.Responses;

namespace PicPayChallenge.Authentication.Application.Users.Services.Interfaces
{
    public interface IUsersAppService
    {
        void RegisterUser(UserRegisterRequest request);
        UserAuthResponse AuthUser(UserAuthRequest request);
        UserResponse GetUser(int id);
    }
}
