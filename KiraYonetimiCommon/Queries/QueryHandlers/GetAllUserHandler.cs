
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KiraYonetimi.DataAcsses;
using KiraYonetimi.DataAcsses.Context;
using KiraYonetimi.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using KiraYonetimi.Common.Queries.QueryRequest;
using KiraYonetimi.DataAcsses.Repositories;
using System.Reflection.Metadata.Ecma335;
/*
namespace KiraYonetimi.Common.Queries.QueryHandlers
{


    public class GetAllPaymentHandler : IRequestHandler<GetAllPaymentQuery, IList<GetAllPaymentQueryResult>>
    {
        private readonly KiraContext _context;

        public GetAllUserQueryHandler(KiraContext context)
        {
            _context = context;
        }


        public async Task<IList<GetAllUserQueryResult>> Handle(
              GetAllUserQuery request,
              CancellationToken cancellationToken)
        {
            return await _context.Users
                .Select(u => new GetAllUserQueryResult
                {  
                    UserId = u.UserId,
                    FullName = u.FullName,
                    Email = u.Email,
                    TcNo = u.TcNo,
                    Phone = u.Phone,
                    PlakaNo = u.PlakaNo,   
                    Role = u.Role 
                })
                .ToListAsync(cancellationToken);
        }

        Task<IList<GetAllPaymentQueryResult>> IRequestHandler<GetAllPaymentQuery, IList<GetAllPaymentQueryResult>>.Handle(GetAllPaymentQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
};

*/