using PicPayChallenge.Authentication.Domain.Users.Entities;
using PicPayChallenge.Authentication.Domain.Users.Repositories;
using PicPayChallenge.Authentication.Domain.Users.Services.Commands;
using PicPayChallenge.Authentication.Domain.Users.Services.Interfaces;
using PicPayChallenge.Common.Exceptions;
using PicPayChallenge.Common.Utils;

namespace PicPayChallenge.Payment.Domain.Users.Services
{
    public class UsersService : IUsersService
    {
        private readonly IUsersRepository usersRepository;

        public UsersService(IUsersRepository usersRepository)
        {
            this.usersRepository = usersRepository;
        }

        public User Instance(UserInstanceCommand command)
        {
            return new User(command.FullName, command.DocumentNumber, command.Email, command.Password, command.UserType);
        }

        public void RegisterUser(User user)
        {
            var userQuery = usersRepository.Query();

            User? userEmail = userQuery.Where(x => x.Email == user.Email).FirstOrDefault();

            if (userEmail.IsNotNull())
                throw new BusinessRuleException("The user only can have one account per email.");

            User? userDocument = userQuery.Where(x => x.DocumentNumber == user.DocumentNumber).FirstOrDefault();

            if (userDocument.IsNotNull())
                throw new BusinessRuleException("The user only can have one account per document number.");

            usersRepository.Insert(user);
        }

        public User Validate(int userId)
        {
            User user = usersRepository.Get(userId);

            if (user.IsNull())
                throw new NotFoundException("User not found");

            return user;
        }
    }
}
