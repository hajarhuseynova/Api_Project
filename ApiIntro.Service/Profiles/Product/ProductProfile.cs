using ApiIntro.Core.Entities;

using ApiIntro.Service.Dtos.Products;
using AutoMapper;

namespace ApiIntro.Profiles.Products
{
    public class ProductProfile:Profile
    {
        public ProductProfile()
        {
            CreateMap<ProductPostDto, Product>();
            //CreateMap<ProductUpdateDto, Product>();
            CreateMap<Product, ProductGetDto>();
        }
    }
}
