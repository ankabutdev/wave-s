using MediatR;

namespace OrderService.Application.UseCases.Orders.Commands.CreateOrder;

public class CreateOrderCommand : IRequest<bool>
{
    public int UserId { get; set; }

    public string Description { get; set; } = string.Empty;

    public int ProductId { get; set; }
}
