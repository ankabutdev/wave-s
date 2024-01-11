using MediatR;
using ProductService.Domain.Entities;

namespace ProductService.Application.UseCases.Companies.Queries.GetAllCompany;

public class GetAllCompanyQuery : IRequest<IEnumerable<Company>>
{
}
