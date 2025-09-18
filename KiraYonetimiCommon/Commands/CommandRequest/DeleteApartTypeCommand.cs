using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KiraYonetimi.Common.Commands.CommandRequest
{
    public sealed record DeleteApartTypeCommand(Guid PkId, string? TypeName) : IRequest<bool>;
   
}
