using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OrderService.Application.Abstractions;

namespace OrderService.Application.UseCases.Orders.Commands.DeleteOrder;

public class OrderDeleteCommandHandler : IRequestHandler<OrderDeleteCommand, bool>
{
    private readonly IAppDbContext _context;
    private readonly IMapper _mapper;

    public OrderDeleteCommandHandler(IAppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<bool> Handle(OrderDeleteCommand request, CancellationToken cancellationToken)
    {
        if (request.Id <= 0)
            return false;

        var categories = await _context.Orders
            .FirstOrDefaultAsync(x => x.Id == request.Id);

        if (categories == null)
            return false;

        _context.Orders.Remove(categories);

        var result = await _context
            .SaveChangesAsync(cancellationToken);

        return result > 0;
    }
}
