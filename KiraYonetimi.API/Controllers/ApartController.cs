
using KiraYonetimi.API.Models.Entity;
using KiraYonetimi.Common.Commands.CommandRequest;
using KiraYonetimi.Common.Queries.QueryRequest;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
namespace KiraYonetimi.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]

  
    public class ApartController(IMediator mediator) : BaseController(mediator)
    {
        private readonly IMediator _mediator;

        [HttpGet]
        public async Task<IActionResult> GetAllAparts()
        {
            var response = await _mediator.Send(new GetAllApartQuery());
            return Ok(response);
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateApartCommand command, CancellationToken ct)
        {
            if (!ModelState.IsValid) return ValidationProblem(ModelState);

            Guid id = await _mediator.Send(command, ct);     // now returns Guid
            return CreatedAtRoute("CreateApart", new { id }, new { id });
        }
    }
}
