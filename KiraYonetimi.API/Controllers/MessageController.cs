using KiraYonetimi.Common.Queries.QueryRequest;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KiraYonetimi.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IMediator mediator;

        public MessageController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllMessages()
        {
            var response = await mediator.Send(new GetAllMessageQuery());
            return Ok(response);
        }
    }
}
