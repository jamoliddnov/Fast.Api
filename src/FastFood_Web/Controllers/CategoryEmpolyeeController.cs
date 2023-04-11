using Microsoft.AspNetCore.Mvc;

namespace FastFood_Web.Api.Controllers
{
    [Route("api/categoryEmpolyee")]
    [ApiController]
    public class CategoryEmpolyeeController : ControllerBase
    {
        [HttpGet("categoryEmpolyeeGet")]
        public async Task<IActionResult> GetAll()
        {
            return Ok();
        }
    }
}
