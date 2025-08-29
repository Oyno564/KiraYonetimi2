
using Microsoft.AspNetCore.Mvc;
using MediatR;
using Microsoft.AspNetCore.Mvc.Controllers;
using KiraYonetimi.API.Models.Entity;
namespace KiraYonetimi.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApartController(IMediator mediator) : BaseController(mediator)
    {

        [HttpGet("GetAllApart")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Models.Entity.Apartment>))]
        public async Task<List<Models.Entity.Apartment>> GetAllApart()
        {
            return (List<Models.Entity.Apartment>)await mediator.Send(new Apartment());
        }
    }
}
