using FastFood_Web.Service.Dtos.CategoryEmpolyeeDto;
using FastFood_Web.Service.Interfaces;
using FastFood_Web.Service.Services.Common.PaginationService;
using Microsoft.AspNetCore.Mvc;

namespace FastFood_Web.Api.Controllers
{
    [Route("api/categoryEmpolyee")]
    [ApiController]
    public class CategoryEmpolyeeController : ControllerBase
    {
        private readonly ICategoryEmpolyeeService _categoryEmpolyeeService;
        private readonly int _pageSize = 15;

        public CategoryEmpolyeeController(ICategoryEmpolyeeService categoryEmpolyeeService)
        {
            this._categoryEmpolyeeService = categoryEmpolyeeService;
        }


        [HttpGet("get")]
        public async Task<IActionResult> GetAllAsync(int page)
        {
            return Ok(await _categoryEmpolyeeService.GetAllAsync(new PaginationParams(page, _pageSize)));
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateAsync([FromForm] CreateCategoryEmpolyeeDto dto)
        {
            return Ok(await _categoryEmpolyeeService.CreateAsync(dto));
        }

        [HttpPost("delete")]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            return Ok(await _categoryEmpolyeeService.DeleteAsync(id));
        }

        [HttpPost("update")]
        public async Task<IActionResult> UpdateAsync(long id, [FromForm] CreateCategoryEmpolyeeDto dto)
        {
            return Ok(await _categoryEmpolyeeService.UpdateAsync(id, dto));
        }

    }
}
