using KiraYonetimi.Common.Commands.CommandRequest;
using KiraYonetimi.Common.Queries.QueryRequest;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace KiraYonetimi.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApartTypeController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ApartTypeController(IMediator mediator) => _mediator = mediator;

        [HttpGet("{id:guid}", Name = "GetApartTypeById")]
        public async Task<IActionResult> GetApartTypeById(Guid id, CancellationToken ct)
        {
            var dto = await _mediator.Send(new GetApartTypeByIdQuery(id), ct);
            return dto is null ? NotFound() : Ok(dto);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllApartType(CancellationToken ct)
            => Ok(await _mediator.Send(new GetAllApartTypeQuery(), ct));

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateApartTypeCommand command, CancellationToken ct)
        {
            if (!ModelState.IsValid) return ValidationProblem(ModelState);
            Guid id = await _mediator.Send(command, ct);
            return CreatedAtRoute("GetApartTypeById", new { id }, new { id });
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id, CancellationToken ct)
        {
            var ok = await _mediator.Send(new DeleteApartTypeCommand(id, null), ct);
            return ok ? NoContent() : NotFound();
        }
    }
}
