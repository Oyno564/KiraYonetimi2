using KiraYonetimi.Common.Commands.CommandRequest;
using KiraYonetimi.Common.Queries.QueryRequest;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace KiraYonetimi.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ApartController : BaseController
    {
        public ApartController(IMediator mediator) : base(mediator) { }

        [HttpGet]
        public async Task<IActionResult> GetAllAparts(CancellationToken ct)
        {
            var response = await mediator.Send(new GetAllApartQuery(), ct);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateApartCommand command, CancellationToken ct)
        {
            if (!ModelState.IsValid) return ValidationProblem(ModelState);
            Guid id = await mediator.Send(command, ct);
            return Ok(new { id });
        }
    }
}
