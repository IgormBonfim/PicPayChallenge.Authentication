using AutoMapper;
using PicPayChallenge.Common.Responses;

namespace PicPayChallenge.Common.Profiles
{
    public class PaginationProfile : Profile
    {
        public PaginationProfile()
        {
            CreateMap(typeof(Pagination<>), typeof(Pagination<>));
        }
    }
}
