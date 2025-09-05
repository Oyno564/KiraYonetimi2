
using KiraYonetimi.API.Models.Entity;
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

     
        [HttpGet]
        public async Task<IActionResult> GetAllAparts()
        {
            var response = await mediator.Send(new GetAllApartQuery());
            return Ok(response);
        }
    }
}
