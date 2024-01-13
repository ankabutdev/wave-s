using MediatR;
using Microsoft.EntityFrameworkCore;
using OrderService.Application.Abstractions;
using OrderService.Domain.Entities;

namespace OrderService.Application.UseCases.Orders.Queries.GetByIdOrder;

public class GetByIdOrderQueryHandler : IRequestHandler<GetByIdOrderQuery, Order>
{
    private readonly IAppDbContext _context;

    public GetByIdOrderQueryHandler(IAppDbContext context)
    {
        _context = context;
    }

    public async Task<Order> Handle(GetByIdOrderQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.Orders
            .FirstOrDefaultAsync(x => x.Id == request.Id);

        return result ?? throw new Exception("Order not found!");
    }
}
