/* using KiraYonetimi.Common.Commands.CommandRequest;
using KiraYonetimi.Common.Queries.QueryRequest;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KiraYonetimi.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApartUserController : ControllerBase
    {

        private readonly IMediator _mediator;

        public ApartUserController(IMediator mediator) => _mediator = mediator;
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateApartUserCommand command, CancellationToken ct)
        {
            if (!ModelState.IsValid) return ValidationProblem(ModelState);

            Guid id = await _mediator.Send(command, ct);
              return CreatedAtRoute("GetApartUserById", new { id }, new { id });
            // Alternatif: return CreatedAtAction(nameof(GetApartTypeById), new { id }, new { id });
        }


        // GET /api/ApartUsers/{id}
        [HttpGet("{id:guid}", Name = "GetApartUserById")]
        public async Task<IActionResult> GetApartUserById(Guid id, CancellationToken ct)
        {
            var dto = await _mediator.Send(new GetApartUserByIdQuery(id), ct);
            return dto is null ? NotFound() : Ok(dto);
        }
    }
}
   */