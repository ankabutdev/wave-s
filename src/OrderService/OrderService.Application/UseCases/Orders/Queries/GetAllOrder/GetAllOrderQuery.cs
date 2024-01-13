using MediatR;
using OrderService.Domain.Entities;

namespace OrderService.Application.UseCases.Orders.Queries.GetAllOrder;

public class GetAllOrderQuery : IRequest<IEnumerable<Order>>
{
}
