using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KiraYonetimi.Common.Commands.CommandRequest
{
    public  class CreateApartTypeCommand : IRequest<Guid>
    {

        public Guid ApartTypePkId { get; init; }
        public string? TypeName { get; set; }
    }
}
