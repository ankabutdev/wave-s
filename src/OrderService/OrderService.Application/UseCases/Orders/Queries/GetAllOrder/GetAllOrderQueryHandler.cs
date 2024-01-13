using MediatR;
using Microsoft.EntityFrameworkCore;
using OrderService.Application.Abstractions;
using OrderService.Domain.Entities;

namespace OrderService.Application.UseCases.Orders.Queries.GetAllOrder;

public class GetAllOrderQueryHandler : IRequestHandler<GetAllOrderQuery, IEnumerable<Order>>
{
    private readonly IAppDbContext _context;

    public GetAllOrderQueryHandler(IAppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Order>> Handle(GetAllOrderQuery request, CancellationToken cancellationToken)
    {
        return await _context
            .Orders
            //.Include(x => x.Products)
            .ToListAsync(cancellationToken);
    }
}
