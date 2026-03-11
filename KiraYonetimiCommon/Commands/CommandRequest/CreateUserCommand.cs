using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KiraYonetimi.Common.Commands.CommandRequest
{
  public  class CreateUserCommand : IRequest<Guid>
    {
        public string FullName { get; init; } = default!;
        public string TcNo { get; init; } = default!;
        public string Email { get; init; } = default!;
        public string Password { get; init; } = default!;
        public string Phone { get; init; } = default!;
        public string? PlakaNo { get; init; }
        public bool Role { get; init; }
        public Guid? ApartUserPkId { get; init; }
    }
}
