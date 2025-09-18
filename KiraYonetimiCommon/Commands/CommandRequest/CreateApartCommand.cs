using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KiraYonetimi.Common.Commands.CommandRequest
{
    public class CreateApartCommand : IRequest<Guid>
    {
        public Guid ApartPkId { get; init; }
        public int ApartBlock { get; init; }
        public bool ApartStatus { get; init; } // true ise dolu, false ise boş

        public int ApartFloor { get; init; }

        public int ApartNo { get; init; }

        public bool ApartOwnerOrTenant { get; init; } // true ise owner, false ise kiracı

      
        public Guid ApartTypePkId { get; init; }

        public Guid ApartUserPkId { get; init; }
       
    }
}
