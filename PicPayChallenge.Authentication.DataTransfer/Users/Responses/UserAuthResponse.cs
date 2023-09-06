using PicPayChallenge.Common.Responses;

namespace PicPayChallenge.Authentication.DataTransfer.Users.Responses
{
    public class UserAuthResponse
    {
        public string Token { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public EnumValue UserType { get; set; }
    }
}
