using KiraYonetimi.Common.Commands.CommandRequest;
using KiraYonetimi.Common.Queries.QueryRequest;
using MediatR;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public sealed class UserController : ControllerBase
{
    private readonly IMediator _mediator;
    public UserController(IMediator mediator) => _mediator = mediator;

    [HttpGet]
    public async Task<IActionResult> GetAllUsers(CancellationToken ct)
        => Ok(await _mediator.Send(new GetAllUserQuery(), ct));

    [HttpGet("{id:guid}", Name = "GetUserById")]
    public async Task<IActionResult> GetById([FromRoute] Guid id, CancellationToken ct)
    {
        var dto = await _mediator.Send(new GetUserByIdQuery(id), ct);
        return dto is null ? NotFound() : Ok(dto);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateUserCommand command, CancellationToken ct)
    {
        if (!ModelState.IsValid) return ValidationProblem(ModelState);

        Guid id = await _mediator.Send(command, ct);     // now returns Guid
        return CreatedAtRoute("GetUserById", new { id }, new { id });
    }
}
