using KiraYonetimi.Common.Queries.QueryRequest;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KiraYonetimi.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly IMediator mediator;

        public InvoiceController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllInvoices()
        {
            var response = await mediator.Send(new GetAllInvoiceQuery());
            return Ok(response);
        }
    }
}
