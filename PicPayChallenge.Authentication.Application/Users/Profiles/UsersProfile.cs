using AutoMapper;
using PicPayChallenge.Authentication.DataTransfer.Users.Facts;
using PicPayChallenge.Authentication.DataTransfer.Users.Requests;
using PicPayChallenge.Authentication.Domain.Users.Entities;
using PicPayChallenge.Authentication.Domain.Users.Services.Commands;

namespace PicPayChallenge.Authentication.Application.Users.Profiles
{
    public class UsersProfile : Profile
    {
        public UsersProfile()
        {
            CreateMap<UserRegisterRequest, UserInstanceCommand>();
            CreateMap<User, UserCreatedFact>();
        }
    }
}
