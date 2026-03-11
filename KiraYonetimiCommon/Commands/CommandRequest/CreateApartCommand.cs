using MediatR;

namespace KiraYonetimi.Common.Commands.CommandRequest
{
    public class CreateApartCommand : IRequest<Guid>
    {
        public int ApartBlock          { get; init; }
        public bool ApartStatus        { get; init; }
        public int ApartFloor          { get; init; }
        public int ApartNo             { get; init; }
        public bool ApartOwnerOrTenant { get; init; }
        public int ApartTypeId         { get; init; }
        public int? ApartUserId        { get; init; }
    }
}
