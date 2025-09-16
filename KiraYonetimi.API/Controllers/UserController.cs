using KiraYonetimi.Common.Commands.CommandRequest;
using KiraYonetimi.Common.Queries.QueryRequest;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace KiraYonetimi.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public sealed class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UserController(IMediator mediator) => _mediator = mediator;

        // GET api/user
        [HttpGet]
        public async Task<IActionResult> GetAllUsers(CancellationToken ct)
        {
            var result = await _mediator.Send(new GetAllUserQuery(), ct);
            return Ok(result);
        }

        // GET api/user/{id}
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id, CancellationToken ct)
        {
            // TODO: implement a GetUserByIdQuery and return a UserDto
            throw new NotImplementedException();
        }

        // POST api/user
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateUserCommand req, CancellationToken ct)
        {
            if (!ModelState.IsValid) return ValidationProblem(ModelState);

            // map request -> command (or let the request IS the command)
            var cmd = new CreateUserCommand
            {
                FullName = req.FullName,
                TcNo = req.TcNo,
                Email = req.Email,
                Password = req.Password,     // hash inside handler/service
                Phone = req.Phone,
                PlakaNo = req.PlakaNo,
                Role = req.Role,
                ApartUserPkId = req.ApartUserPkId

            };

            // if your handler returns Guid of the new user (recommended)
            var id = await _mediator.Send(cmd, ct);

            return CreatedAtAction(nameof(GetById), new { id }, new { id });
        }
    }
}
