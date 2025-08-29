
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KiraYonetimi.DataAcsses;
using KiraYonetimi.DataAcsses.Context;
using KiraYonetimi.Entities.Entities;
using System.Data.Entity;
using KiraYonetimi.Common.Queries.QueryRequest;
using KiraYonetimi.DataAcsses.Repositories;
using System.Reflection.Metadata.Ecma335;

namespace KiraYonetimi.Common.Queries.QueryHandlers
{



    public class GetAllUserQueryHandler : IRequestHandler<GetAllUserQuery, IList<GetAllUserQueryResult>>
    {
        private readonly DatabaseUnitOfWork unitOfWork;

        public GetAllUserQueryHandler(DatabaseUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<IList<GetAllUserQueryResult>> Handle(GetAllUserQuery request, CancellationToken cancellationToken)
        {
            var users = await unitOfWork.UserRepository.GetAllAsync();


            List<GetAllUserQueryResult> response = new();
            foreach (var user in users)
            {
                response.Add(new GetAllUserQueryResult
                {
                    UserId = user.UserId,
                    FullName = user.FullName,
                    Email = user.Email,
                    TcNo = user.TcNo,
                    Phone = user.Phone,
                    PlakaNo = user.PlakaNo,
              
                });
            }
            return response;
        } 
    }
}

