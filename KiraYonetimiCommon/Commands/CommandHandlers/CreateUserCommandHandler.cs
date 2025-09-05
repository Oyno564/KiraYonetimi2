using KiraYonetimi.Common.Commands.CommandRequest;
using KiraYonetimi.DataAcsses.Interfaces;
using KiraYonetimi.Entities.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            User user = new(request.UserId, request.FullName, request.TcNo, request.Email, request.Phone, request.PlakaNo, false, null, null, null);

            await unitOfWork.SaveAsync();
            object value = await unitOfWork.UserRepository.AddAsync(user);
        }
    }
} 
