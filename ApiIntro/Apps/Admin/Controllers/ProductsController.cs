using ApiIntro.Service.Dtos.Products;
using ApiIntro.Service.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiIntro.Admin.Controllers
{
    [Authorize(Roles = "Admin,SuperAdmin")]
    [ApiController]
    [Route("api/admin/[controller]")]
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
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] ProductPostDto dto)
        {

            var resslt = await _productService.CreateAsync(dto);
            return StatusCode(resslt.StatusCode, resslt);

        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _productService.RemoveAsync(id);
            return StatusCode(result.StatusCode);

        }
        [HttpPut]
        public async Task<IActionResult> Update(int id, [FromBody] ProductUpdateDto dto)
        {
            var result = await _productService.UpdateAsync(id, dto);
            return StatusCode(result.StatusCode, result);

        }
    }
}
