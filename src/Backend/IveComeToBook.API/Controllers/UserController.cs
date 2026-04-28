using IveComeToBook.Communication.Requests;
using IveComeToBook.Communication.Responses;
using Microsoft.AspNetCore.Mvc;

namespace IveComeToBook.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(ResponseRegisterUserJson), StatusCodes.Status201Created)]
        public IActionResult Register(RequestRegisterUserJson request)
        {
            return Created();
        }
    }
}
