using MediatR;

namespace UserService.Application.UseCases.Orders.Commands.CreateUser;

public class CreateUserCommand : IRequest<bool>
{
    public string FullName { get; set; } = string.Empty;

    public string PhoneNumber { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

}
