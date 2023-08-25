using AutoMapper;
using PicPayChallenge.Authentication.Application.Users.Services.Interfaces;
using PicPayChallenge.Authentication.DataTransfer.Users.Requests;
using PicPayChallenge.Authentication.Domain.Users.Entities;
using PicPayChallenge.Authentication.Domain.Users.Services.Commands;
using PicPayChallenge.Authentication.Domain.Users.Services.Interfaces;

namespace PicPayChallenge.Authentication.Application.Users.Services
{
    public class UsersAppService : IUsersAppService
    {
        private readonly IUsersService userService;
        private readonly IMapper mapper;

        public UsersAppService(IUsersService userService, IMapper mapper)
        {
            this.userService = userService;
            this.mapper = mapper;
        }

        public void AuthUser(UserAuthRequest request)
        {
            throw new NotImplementedException();
        }

        public void RegisterUser(UserRegisterRequest request)
        {
            UserInstanceCommand command = mapper.Map<UserInstanceCommand>(request);

            User user = userService.Instance(command);
            userService.RegisterUser(user);
        }
    }
}
