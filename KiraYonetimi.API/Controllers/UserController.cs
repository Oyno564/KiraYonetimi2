using KiraYonetimi.Common.Queries.QueryRequest;
using KiraYonetimi.DataAcsses.Context;
using KiraYonetimi.Entities.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace KiraYonetimi.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly KiraContext _context;

        public UserController(KiraContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var response = await _mediator.Send(new GetAllUserQuery());
            return Ok(response);
        }


        [HttpPost]
       public async Task<IActionResult> Create([FromBody] User user)
        {
            if (user == null) return BadRequest();

            _context.Users.Add(user);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetAllUsers), new { id = user.UserId }, user);
        }
    }

    
}
 