using Microsoft.Extensions.Options;
using PicPayChallenge.Authentication.Domain.Users.Entities;
using PicPayChallenge.Authentication.Domain.Users.Repositories;
using PicPayChallenge.Authentication.Domain.Users.Services.Commands;
using PicPayChallenge.Authentication.Domain.Users.Services.Interfaces;
using PicPayChallenge.Common.Exceptions;
using PicPayChallenge.Common.Tokens;
using PicPayChallenge.Common.Utils;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace PicPayChallenge.Payment.Domain.Users.Services
{
    public class UsersService : IUsersService
    {
        private readonly IUsersRepository usersRepository;
        private readonly TokenOptions tokenOptions;

        public UsersService(IUsersRepository usersRepository, IOptions<TokenOptions> tokenOptions)
        {
            this.usersRepository = usersRepository;
            this.tokenOptions = tokenOptions.Value;
        }

        public User AuthUser(UserAuthCommand command)
        {
            if (!EmailUtil.IsValid(command.Email))
                throw new BadRequestException("Email is not valid");

            User? user = usersRepository.Query()
                .Where(user => user.Email.ToUpper() == command.Email.ToUpper())
                .FirstOrDefault();

            if (user.IsNull())
                throw new NotFoundException("Email not found");

            bool loged = PasswordUtil.ComparePassword(user!.Password, command.Password);

            if (!loged)
                throw new BadRequestException("Incorrect password");

            return user;
        }

        public User Instance(UserInstanceCommand command)
        {
            return new User(command.FullName, command.DocumentNumber, command.Email, command.Password, command.UserType);
        }

        public User RegisterUser(User user)
        {
            var userQuery = usersRepository.Query();

            User? userEmail = userQuery.Where(x => x.Email == user.Email).FirstOrDefault();

            if (userEmail.IsNotNull())
                throw new BusinessRuleException("The user only can have one account per email.");

            User? userDocument = userQuery.Where(x => x.DocumentNumber == user.DocumentNumber).FirstOrDefault();

            if (userDocument.IsNotNull())
                throw new BusinessRuleException("The user only can have one account per document number.");

            return usersRepository.Insert(user);
        }

        public string GenerateToken(User user)
        {
            DateTime dataExpiracao = DateTime.Now.AddHours(tokenOptions.Expiration);

            IList<Claim> tokenClaims = new List<Claim> 
            {
                new Claim("Email", user.Email),
                new Claim("UserId", user.Id.ToString()),
            };

            JwtSecurityToken jwt = new JwtSecurityToken(
                issuer: tokenOptions.Issuer,
                audience: tokenOptions.Audience,
                claims: tokenClaims,
                notBefore: DateTime.Now,
                expires: dataExpiracao,
                signingCredentials: tokenOptions.SigningCredentials
            );

            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }
    }
}
