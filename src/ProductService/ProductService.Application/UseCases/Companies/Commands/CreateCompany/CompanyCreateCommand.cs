using MediatR;

namespace ProductService.Application.UseCases.Companies.Commands.CreateCompany;

public class CompanyCreateCommand : IRequest<bool>
{
    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public string CompanyPhoneNumber { get; set; } = string.Empty;

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public string Email { get; set; } = string.Empty;
}
