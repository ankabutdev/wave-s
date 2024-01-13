using MediatR;

namespace OrderService.Application.UseCases.Orders.Commands.DeleteOrder;

public class OrderDeleteCommand : IRequest<bool>
{
    public int Id { get; set; }
}
