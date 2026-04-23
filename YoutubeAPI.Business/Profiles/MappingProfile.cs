using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using YoutubeAPI.Core.Product; // Ensure correct namespace for Product and ProductDto

namespace YoutubeAPI.Business.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<ProductDto, ProductSaveDto>();
            CreateMap<ProductSaveDto, Product>();
        }

    }
}
