using MediatR;

namespace KiraYonetimi.Common.Queries.QueryRequest
{
    // record style is concise
    public sealed record GetUserByIdQuery(Guid Id) : IRequest<GetUserByIdResult?>;


}
