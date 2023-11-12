using PicPayChallenge.Common.Responses;

namespace PicPayChallenge.Authentication.DataTransfer.Users.Responses
{
    public class UserAuthResponse
    {
        public string Token { get; set; }
        public UserResponse User { get; set; }
    }
}
