using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using KiraYonetimi.Common.Queries.QueryRequest;
namespace KiraYonetimi.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator mediator;

        public UserController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var response = await mediator.Send(new GetAllUserQuery());
            return Ok(response);
        }
    }
}
 