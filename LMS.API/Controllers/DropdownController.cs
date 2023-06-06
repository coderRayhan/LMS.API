using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DropdownController : ControllerBase
    {
        
        [HttpGet]
        public async Task<IActionResult> GetLookups()
        {
            return Ok();
        }
    }
}
