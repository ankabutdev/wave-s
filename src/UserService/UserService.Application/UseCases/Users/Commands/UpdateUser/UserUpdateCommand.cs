using MediatR;

namespace UserService.Application.UseCases.Orders.Commands.UpdateUser;

public class UserUpdateCommand : IRequest<bool>
{
    public int Id { get; set; }

    public string FullName { get; set; } = string.Empty;

    public string PhoneNumber { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public DateTime UpdatedAt { get; set; }
}
