﻿using AutoMapper;
using MediatR;
using ProductService.Application.Abstractions;
using ProductService.Application.Interfaces.Files;
using ProductService.Domain.Entities;

namespace ProductService.Application.UseCases.Products.Commands.CreateProduct;

public class ProductCreateCommandHandler : IRequestHandler<ProductCreateCommand, bool>
{
    private readonly IAppDbContext _context;
    private readonly IMapper _mapper;
    private readonly IFileService _fileService;

    public ProductCreateCommandHandler(IAppDbContext context, IMapper mapper, IFileService fileService)
    {
        _context = context;
        _mapper = mapper;
        _fileService = fileService;
    }

    public async Task<bool> Handle(ProductCreateCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = _mapper.Map<Product>(request);

            string imagePath = await _fileService
                .UploadImageAsync(request.ImagePaths);

            entity.ImagePaths = imagePath;

            entity.CreatedAt = DateTime.UtcNow;
            entity.UpdatedAt = DateTime.UtcNow;

            await _context.Products.AddAsync(entity, cancellationToken);

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
