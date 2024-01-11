using MediatR;
using ProductService.Domain.Entities;

namespace ProductService.Application.UseCases.Companies.Queries.GetByIdCompany;

public class GetByIdCompanyQuery : IRequest<Company>
{
    public int Id { get; set; }
}

