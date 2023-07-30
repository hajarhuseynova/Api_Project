using Microsoft.AspNetCore.Http;

namespace ApiIntro.Service.Dtos.Products
{
    public class ProductUpdateDto
    {
        public string? Name { get; set; }
        public double? Price { get; set; }
        public IFormFile? File { get; set; }
        public int? CategoryId { get; set; }

    }
}
