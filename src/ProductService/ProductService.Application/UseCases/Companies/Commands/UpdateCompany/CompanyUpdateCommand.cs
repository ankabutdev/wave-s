using MediatR;

namespace ProductService.Application.UseCases.Companies.Commands.UpdateCompany;

public class CompanyUpdateCommand : IRequest<bool>
{
    public long Id { get; set; }

    public string Description { get; set; } = string.Empty;

    public string Name { get; set; } = string.Empty;

    public string CompanyPhoneNumber { get; set; } = string.Empty;

    public DateTime UpdatedAt { get; set; }

    public string Email { get; set; } = string.Empty;
}
