using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicPayChallenge.Common.Tokens
{
    public class TokenOptions
    {
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public SigningCredentials SigningCredentials { get; set; }
        public int Expiration { get; set; }
    }
}
