using IveComeToBook.Application.UseCases.User.Register;
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
        public async Task<IActionResult> Register([FromServices] IRegisterUserUseCase useCase, [FromBody]RequestRegisterUserJson request)
        {
            var result = await useCase.Execute(request);

            return Created(string.Empty, result);
        }
    }
}
