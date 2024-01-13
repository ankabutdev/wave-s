using AutoMapper;
using MediatR;
using OrderService.Application.Abstractions;
using OrderService.Domain.Entities;

namespace OrderService.Application.UseCases.Orders.Commands.CreateOrder;

public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, bool>
{
    private readonly IAppDbContext _context;
    private readonly IMapper _mapper;

    public CreateOrderCommandHandler(IAppDbContext context,
        IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<bool> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = _mapper.Map<Order>(request);

            entity.CreatedAt = DateTime.UtcNow;
            entity.UpdatedAt = DateTime.UtcNow;

            await _context.Orders.AddAsync(entity);

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
