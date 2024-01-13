using MediatR;

namespace UserService.Application.UseCases.Orders.Commands.DeleteUser;

public class UserDeleteCommand : IRequest<bool>
{
    public int Id { get; set; }
}
