using MediatR;

namespace OrderService.Application.UseCases.Orders.Commands.UpdateOrder;

public class OrderUpdateCommand : IRequest<bool>
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public string Description { get; set; } = string.Empty;

    public DateTime UpdatedAt { get; set; }

    public int ProductId { get; set; }
}
