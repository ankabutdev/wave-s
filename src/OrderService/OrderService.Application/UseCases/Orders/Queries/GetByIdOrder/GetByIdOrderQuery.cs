using MediatR;
using OrderService.Domain.Entities;

namespace OrderService.Application.UseCases.Orders.Queries.GetByIdOrder;

public class GetByIdOrderQuery : IRequest<Order>
{
    public int Id { get; set; }
}
