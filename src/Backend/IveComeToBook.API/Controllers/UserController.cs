using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IveComeToBook.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpPost]
        public IActionResult Register()
        {
            return Created();
        }
    }
}
