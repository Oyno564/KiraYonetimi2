using MediatR;
using KiraYonetimi.Entities.Entities;
namespace KiraYonetimi.Common.Queries.QueryRequest;

public class GetAllApartQuery : IRequest<List<Apartment>>
{

}