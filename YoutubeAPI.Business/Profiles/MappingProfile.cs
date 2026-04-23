using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using YoutubeAPI.Core.Product;
using YoutubeAPI.Core.User;
namespace YoutubeAPI.Business.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<ProductDto, ProductSaveDto>();
            CreateMap<ProductSaveDto, Product>();

            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<UserDto, UserSaveDto>();
            CreateMap<UserSaveDto, User>();
        }

    }
}
