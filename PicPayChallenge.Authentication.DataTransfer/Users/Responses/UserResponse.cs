using PicPayChallenge.Common.Responses;

namespace PicPayChallenge.Authentication.DataTransfer.Users.Responses
{
    public class UserResponse
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public EnumValue UserType { get; set; }
    }
}
