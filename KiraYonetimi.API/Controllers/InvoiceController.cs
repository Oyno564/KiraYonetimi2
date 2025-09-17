using KiraYonetimi.Common.Commands.CommandRequest;
using KiraYonetimi.Common.Queries.QueryRequest;
using MediatR;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class InvoiceController : ControllerBase
{
    private readonly IMediator _mediator;
    public InvoiceController(IMediator mediator) => _mediator = mediator;

    // 1) İsimlendirilmiş GET rotası
    [HttpGet("{id}", Name = "GetInvoiceById")]
    public async Task<IActionResult> GetInvoiceById(Guid id, CancellationToken ct)
    {
        var dto = await _mediator.Send(new GetInvoiceByIdQuery(id), ct);
        return dto is null ? NotFound() : Ok(dto);
    }

    // 2) POST -> CreatedAtRoute ile aynı "Name" ve aynı parametre adı
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateInvoiceCommand command, CancellationToken ct)
    {
        if (!ModelState.IsValid) return ValidationProblem(ModelState);

        var id = await _mediator.Send(command, ct);   // Guid dönüyor
        if (id == Guid.Empty) return Problem("Id üretilemedi.");

        return CreatedAtRoute("GetInvoiceById", new { id }, new { id });
        // Alternatif: return CreatedAtAction(nameof(GetInvoiceById), new { id }, new { id });
    }
}
