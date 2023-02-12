using Artisanaux.Service.ProductAPI.Models;
using Artisanaux.Service.ProductAPI.Models.Dto;
using AutoMapper;

namespace Artisanaux.Service.ProductAPI
{
    public class AutoMapping
    {
        public static MapperConfiguration RegisterMaps()
        {
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<Product, ProductDto>().ReverseMap();
                    
                });
                return config;
            }
        }
         
    }
}
