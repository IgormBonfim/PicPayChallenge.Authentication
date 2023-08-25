namespace PicPayChallenge.Authentication.DataTransfer.Users.Requests
{
    public class UserRegisterRequest
    {
        public string FullName { get; set; }
        public string DocumentNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int UserType { get; set; }
    }
}
