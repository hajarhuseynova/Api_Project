using ApiIntro.Core.Entities;
using ApiIntro.Service.Dtos.Categories;

using AutoMapper;

namespace ApiIntro.Profiles.Categories
{
    public class ProductProfile:Profile
    {
        public ProductProfile()
        {
            CreateMap<CategoryPostDto, Category>();
            CreateMap<CategoryUpdateDto, Category>();
            CreateMap<Category, CategoryGetDto>();
        }
    }
}
