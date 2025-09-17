using KiraYonetimi.Common.Commands.CommandRequest;
using MediatR;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class ApartTypeController : ControllerBase
{
    private readonly IMediator _mediator;
    public ApartTypeController(IMediator mediator) => _mediator = mediator;

    // GET /api/ApartType/{id}
    [HttpGet("{id:guid}", Name = "GetApartTypeById")]
    public async Task<IActionResult> GetApartTypeById(Guid id, CancellationToken ct)
    {
        var dto = await _mediator.Send(new GetApartTypeByIdQuery(id), ct);
        return dto is null ? NotFound() : Ok(dto);
    }

    // POST /api/ApartType
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateApartTypeCommand command, CancellationToken ct)
    {
        if (!ModelState.IsValid) return ValidationProblem(ModelState);

        Guid id = await _mediator.Send(command, ct);
        return CreatedAtRoute("GetApartTypeById", new { id }, new { id });
        // Alternatif: return CreatedAtAction(nameof(GetApartTypeById), new { id }, new { id });
    }
}
