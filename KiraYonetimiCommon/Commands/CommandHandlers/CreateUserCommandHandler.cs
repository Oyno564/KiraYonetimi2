using KiraYonetimi.Common.Commands.CommandRequest;
using KiraYonetimi.DataAcsses.Interfaces;
using KiraYonetimi.Entities.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace KiraYonetimi.Common.Commands.CommandHandlers
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
    {
        private readonly IDatabaseUnitOfWork unitOfWork;

        public CreateUserCommandHandler(IDatabaseUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            // Create entity
            User user = new(request.UserId, request.FullName, request.TcNo,
                            request.Email, request.Phone, request.PlakaNo,
                            false, null, null, null);

            // Save through repository
            await unitOfWork.Users.AddAsync(user);  // <-- assuming Users repo is exposed in UnitOfWork
            Task<T> await unitOfWork.SaveAsync();   // return number of affected rows
        }
    }
}
