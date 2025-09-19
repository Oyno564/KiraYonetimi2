using MediatR;
using System;

namespace KiraYonetimi.Common.Commands.CommandRequest
{
    public sealed class CreateApartCommand : IRequest<Guid>
    {
        // REMOVE: public Guid ApartPkId { get; init; }  // PK comes from server

        public int ApartBlock { get; init; }
        public bool ApartStatus { get; init; } // true=dolu, false=boş
        public int ApartFloor { get; init; }
        public int ApartNo { get; init; }
        public bool ApartOwnerOrTenant { get; init; } // true=owner, false=kiracı

        public Guid ApartTypePkId { get; init; }       // REQUIRED (FK -> ApartType.PkId)

        // Uncomment ONLY if Apartments.ApartUserPkId is NOT NULL in DB:
        // public Guid ApartUserPkId { get; init; }     // REQUIRED if schema demands it
    }
}
