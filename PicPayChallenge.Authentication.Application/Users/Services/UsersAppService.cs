using AutoMapper;
using PicPayChallenge.Authentication.Application.Users.Services.Interfaces;
using PicPayChallenge.Authentication.DataTransfer.Users.Facts;
using PicPayChallenge.Authentication.DataTransfer.Users.Requests;
using PicPayChallenge.Authentication.DataTransfer.Users.Responses;
using PicPayChallenge.Authentication.Domain.Users.Entities;
using PicPayChallenge.Authentication.Domain.Users.Producers;
using PicPayChallenge.Authentication.Domain.Users.Services.Commands;
using PicPayChallenge.Authentication.Domain.Users.Services.Interfaces;

namespace PicPayChallenge.Authentication.Application.Users.Services
{
    public class UsersAppService : IUsersAppService
    {
        private readonly IUsersService userService;
        private readonly IUserCreatedProducer userCreatedProducer;
        private readonly IMapper mapper;

        public UsersAppService(IUsersService userService, IUserCreatedProducer userCreatedProducer, IMapper mapper)
        {
            this.userService = userService;
            this.userCreatedProducer = userCreatedProducer;
            this.mapper = mapper;
        }

        public UserAuthResponse AuthUser(UserAuthRequest request)
        {
            UserAuthCommand command = mapper.Map<UserAuthCommand>(request);
            User user = userService.AuthUser(command);

            return new UserAuthResponse
            {
                Token = userService.GenerateToken(user),
                User = mapper.Map<UserResponse>(user)
            };
        }

        public UserResponse GetUser(int id)
        {
            User user = userService.Validate(id);

            return mapper.Map<UserResponse>(user);
        }

        public void RegisterUser(UserRegisterRequest request)
        {
            UserInstanceCommand command = mapper.Map<UserInstanceCommand>(request);

            User user = userService.Instance(command);
            user = userService.RegisterUser(user);

            UserCreatedFact userFact = mapper.Map<UserCreatedFact>(user);
            userCreatedProducer.sendMessage(userFact);
        }
    }
}
