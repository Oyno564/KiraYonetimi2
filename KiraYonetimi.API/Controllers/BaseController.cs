using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KiraYonetimi.API.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public abstract class BaseController(IMediator mediator) : ControllerBase
    {
        protected readonly IMediator mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }
}