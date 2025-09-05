using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KiraYonetimi.Common.Commands.CommandRequest
{
    internal class CreateUserCommand : IRequest
    {
        public int UserId { get; set; }
        public string? FullName { get; set; }
        public int TcNo { get; set; }
        public string? Email { get; set; }

        public int Phone { get; set; }  

        public string? PlakaNo { get; set; }
    }
}
