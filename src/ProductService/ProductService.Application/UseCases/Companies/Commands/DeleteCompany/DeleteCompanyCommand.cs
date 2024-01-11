using MediatR;

namespace ProductService.Application.UseCases.Companies.Commands.DeleteCompany;

public class DeleteCompanyCommand : IRequest<bool>
{
    public int Id { get; set; }
}
