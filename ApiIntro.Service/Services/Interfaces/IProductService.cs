
using ApiIntro.Service.Dtos.Products;
using ApiIntro.Service.Responses;

namespace ApiIntro.Service.Services.Interfaces
{
    public interface IProductService
    {
        public Task<ApiResponse> CreateAsync(ProductPostDto dto);
        public Task<ApiResponse> GetAsync(int id);
        public Task<ApiResponse> GetAllAsync();
        public Task<ApiResponse> UpdateAsync(int id, ProductUpdateDto dto);
        public Task<ApiResponse> RemoveAsync(int id);
    }
}
