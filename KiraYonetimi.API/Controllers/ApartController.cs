using KiraYonetimi.Common.Commands.CommandRequest;
using MediatR;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]/[action]")]
public class ApartController : ControllerBase
{
    private readonly IMediator _mediator;
    public ApartController(IMediator mediator) =>
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));

    [HttpPost]
public async Task<IActionResult> Create([FromBody] CreateApartCommand cmd, CancellationToken ct)
{
    if (cmd is null) return BadRequest("Request body is required.");
    if (!ModelState.IsValid) return ValidationProblem(ModelState);

    var id = await _mediator.Send(cmd, ct);

    // no GetById route -> just return 201 Created with the new id in the body
    return Created(string.Empty, new { id });
}


  
}
