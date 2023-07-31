
using ApiIntro.Core.Entities;
using ApiIntro.Core.Repositories;
using ApiIntro.Service.Dtos.Products;
using ApiIntro.Service.Helpers;
using ApiIntro.Service.Responses;
using ApiIntro.Service.Services.Interfaces;

using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace ApiIntro.Service.Services.Implementations
{
    public class ProductService:IProductService
    {
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _env;
        private readonly IHttpContextAccessor _http;
        private readonly ICategoryRepository _crepository;
        private readonly IProductRepository _repository;

        public ProductService(IMapper mapper, IProductRepository repository, IWebHostEnvironment env = null, ICategoryRepository crepository = null, IHttpContextAccessor http = null)
        {
            _mapper = mapper;
            _repository = repository;
            _env = env;
            _crepository = crepository;
            _http = http;
        }

        public async Task<ApiResponse> CreateAsync(ProductPostDto dto)
        {
            if (!await _crepository.IsExsist(x=>x.Id==dto.CategoryId))
            {
                return new ApiResponse { StatusCode = 404, Description = "already exsists" };
            }

            Product Product = _mapper.Map<Product>(dto);
            Product.Image = dto.File.CreateImage(_env.WebRootPath, "assets/images");


            Product.ImageUrl = _http.HttpContext.Request.Scheme +
                "://" + _http.HttpContext.Request.Host
                + $"/assets/images/{Product.Image}";

            await _repository.AddAsync(Product);
            await _repository.SaveAsync();
            return new ApiResponse { StatusCode = 201};
        }

        public async Task<ApiResponse> GetAllAsync()
        {
            IQueryable<Product> query = await _repository.GetAllAsync(x => !x.IsDeleted,"Category");
            List<ProductGetDto> products = new List<ProductGetDto>();

            products = await query.Select(x => new ProductGetDto { Name = x.Name,Price=x.Price,
                CategoryId=x.CategoryId,Image=x.Image,ImageUrl=x.ImageUrl,CategoryName=x.Category.Name
            }).ToListAsync();

            return new ApiResponse { Items = products, StatusCode = 200 };

        }

        public async Task<ApiResponse> GetAsync(int id)
        {
            Product? Product = await _repository.GetAsync(x => x.Id == id && !x.IsDeleted,"Category");

            if (Product == null)
            {
                return new ApiResponse { StatusCode = 404, Description = "Item not found" };
            }

            ProductGetDto getDto = _mapper.Map<ProductGetDto>(Product);

            getDto.CategoryName=Product.Category.Name;  

            return new ApiResponse { Items = getDto, StatusCode = 200 };
        }

        public async  Task<ApiResponse> RemoveAsync(int id)
        {
            Product? Product = await _repository.GetAsync(x => x.Id == id && !x.IsDeleted);

            if (Product == null)
            {
                return new ApiResponse { StatusCode = 404, Description = "Item not found" };
            }
            Product.IsDeleted = true;
            await _repository.Update(Product);
            await _repository.SaveAsync();
            return new ApiResponse { StatusCode = 204 };
        }

        public async Task<ApiResponse> UpdateAsync(int id, ProductUpdateDto dto)
        {
            Product? Product = await _repository.GetAsync(x => x.Id == id && !x.IsDeleted);

            if (Product == null)
            {
                return new ApiResponse { StatusCode = 404, Description = "Item not found" };
            }
            Product.Name = dto.Name;
            Product.Price = (double)dto.Price;
            Product.CategoryId =(int)dto.CategoryId;
            Product.Image = dto.File == 
                null ? Product.Image : dto.File.CreateImage(_env.WebRootPath, "assets/images");

            await _repository.Update(Product);
            await _repository.SaveAsync();
            return new ApiResponse { StatusCode = 204 };
        }
    }
}
