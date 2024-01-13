using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OrderService.Application.Abstractions;

namespace OrderService.Application.UseCases.Orders.Commands.UpdateOrder;

public class OrderUpdateCommandHandler : IRequestHandler<OrderUpdateCommand, bool>
{
    private readonly IAppDbContext _context;
    private readonly IMapper _mapper;

    public OrderUpdateCommandHandler(IAppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<bool> Handle(OrderUpdateCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var categories = await _context.Orders
            .FirstOrDefaultAsync(x => x.Id == request.Id);

            if (categories is null)
                throw new ArgumentNullException(nameof(categories));

            _mapper.Map(request, categories);

            categories.UpdatedAt = DateTime.UtcNow;

            _context.Orders.Update(categories);

            var result = await _context
                .SaveChangesAsync(cancellationToken);

            return result > 0;
        }
        catch
        {
            return false;
        }
    }
}
