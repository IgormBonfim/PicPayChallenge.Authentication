using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicPayChallenge.Authentication.DataTransfer.Users.Facts
{
    public class UserCreatedFact
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string DocumentNumber { get; set; }
        public string Email { get; set; }
        public int UserType { get; set; }
    }
}
