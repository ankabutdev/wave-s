using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ProductService.Application.Abstractions;

namespace ProductService.Application.UseCases.Products.Commands.UpdateProduct;

public class ProductUpdateCommandHandler : IRequestHandler<ProductUpdateCommand, bool>
{
    private readonly IAppDbContext _context;
    private readonly IMapper _mapper;

    public ProductUpdateCommandHandler(IAppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<bool> Handle(ProductUpdateCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var products = await _context.Products
            .FirstOrDefaultAsync(x => x.Id == request.Id);

            if (products is null)
                throw new ArgumentNullException(nameof(products));

            _mapper.Map(request, products);

            products.UpdatedAt = DateTime.UtcNow;

            _context.Products.Update(products);

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
