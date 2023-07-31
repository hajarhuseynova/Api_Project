using ApiIntro.Service.Dtos.Products;
using ApiIntro.Service.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ApiIntro.Client.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {

            return StatusCode(200, await _productService.GetAllAsync());

        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _productService.GetAsync(id);
            return StatusCode(result.StatusCode, result);
        }

    }
}
