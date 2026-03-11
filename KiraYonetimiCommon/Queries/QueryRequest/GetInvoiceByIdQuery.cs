using KiraYonetimi.Common.Queries.QueryRequest;
using MediatR;

public sealed record GetInvoiceByIdQuery(Guid PkId) : IRequest<GetInvoiceByIdResult?>;