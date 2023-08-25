using AutoMapper;
using PicPayChallenge.Common.Responses;
using PicPayChallenge.Common.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicPayChallenge.Common.Profiles
{
    public class EnumValueProfile : Profile
    {
        public EnumValueProfile()
        {
            CreateMap<Enum, EnumValue>()
                .ForMember(dest => dest.Description, opt => opt.MapFrom(source => source.GetEnumDescription()))
                .ForMember(dest => dest.Value, opt => opt.MapFrom(source => Convert.ToInt32(source)));
        }
    }
}
