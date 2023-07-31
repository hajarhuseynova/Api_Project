

using ApiIntro.Service.Dtos.Categories;
using ApiIntro.Service.Services.Interfaces;

using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiIntro.Admin.Controllers
{
    [Authorize(Roles = "Admin,SuperAdmin")]
    [ApiController]
    [Route("api/admin/[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {

            return StatusCode(200, await _categoryService.GetAllAsync());

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _categoryService.GetAsync(id);
            return StatusCode(result.StatusCode, result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CategoryPostDto dto)
        {

            var resslt = await _categoryService.CreateAsync(dto);
            return StatusCode(resslt.StatusCode, resslt);
         
        }
         [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _categoryService.RemoveAsync(id);
            return StatusCode(result.StatusCode);

        }
        [HttpPut]
        public async Task<IActionResult> Update(int id, [FromBody] CategoryUpdateDto dto)
        {
            var result = await _categoryService.UpdateAsync(id, dto);
            return StatusCode(result.StatusCode, result);

        }


        //private Category Map(CategoryPostDto dto)
        //{
        //    return new Category
        //    {
        //        Name = dto.Name,
        //        Description = dto.Description,
        //    };
        //}

    }
}
