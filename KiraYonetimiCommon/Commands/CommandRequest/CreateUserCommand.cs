using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KiraYonetimi.Common.Commands.CommandRequest
{
  public  class CreateUserCommand : IRequest<int>
    {
        public int UserId { get; set; }

        public Guid? ApartUserPkId { get; init; }
        public string? FullName { get; set; }
        public string TcNo { get; set; }

        public string Password { get; init; }
        public string? Email { get; set; }

        public bool Role { get; set; }

        public string Phone { get; set; }  

        public string? PlakaNo { get; set; }
    }
}
