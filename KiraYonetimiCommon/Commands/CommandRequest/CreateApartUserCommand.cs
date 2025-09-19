/* using MediatR;
using System.ComponentModel.DataAnnotations;

namespace KiraYonetimi.Common.Commands.CommandRequest
{
    // User'ın PkId'si yeterli; daire bağlamak istersen ApartmentPkId gönderirsin (opsiyonel)
    public sealed class CreateApartUserCommand : IRequest<Guid>
    {
        [Required] public Guid UserPkId { get; init; }
        public Guid? ApartmentPkId { get; init; }
    }
}
  */