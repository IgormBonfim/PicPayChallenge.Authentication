using PicPayChallenge.Authentication.Domain.Users.Enums;

namespace PicPayChallenge.Authentication.Domain.Users.Services.Commands
{
    public class UserInstanceCommand
    {
        public string FullName { get; set; }
        public string DocumentNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public UserTypeEnum UserType { get; set; }
    }
}
