using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProductService.Application.DTOs;
using ProductService.Application.DTOs.Products;
using ProductService.Application.UseCases.Products.Commands.CreateProduct;
using ProductService.Application.UseCases.Products.Commands.DeleteProduct;
using ProductService.Application.UseCases.Products.Commands.UpdateProduct;
using ProductService.Application.UseCases.Products.Queries.GetAllProduct;
using ProductService.Application.UseCases.Products.Queries.GetByIdProduct;

namespace ProductService.Api.Controllers;

[Route("api/products/")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public ProductsController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpGet]
    public async ValueTask<IActionResult> GetAllAsync()
    {
        return Ok(await _mediator.Send(new GetAllProductQuery()));
    }

    [HttpGet("{Id}")]
    public async ValueTask<IActionResult> GetByIdAsync(int Id)
    {
        var result = await _mediator
            .Send(new GetByIdProductQuery { Id = Id });

        return Ok(result);
    }

    [HttpPost]
    public async ValueTask<IActionResult> CreateAsync([FromForm] ProductCreateDto dto)
    {
        var product = _mapper.Map<ProductCreateCommand>(dto);

        var result = await _mediator.Send(product);

        return Ok(result);
    }

    [HttpPut("{Id}")]
    public async Task<IActionResult> UpdateAsync(int Id, ProductUpdateDto dto)
    {
        var product = _mapper.Map<ProductUpdateCommand>(dto);
        product.Id = Id;
        var result = await _mediator.Send(product);
        return Ok(result);
    }

    [HttpDelete("{Id}")]
    public async Task<IActionResult> DeleteAsync(int Id)
    {
        var result = await _mediator
            .Send(new ProductDeleteCommand() { Id = Id });

        return Ok(result);
    }

    [HttpPost("file")]
    public async Task<IActionResult> Create([FromForm] FIleDto fileDto)
    {
        fileDto.ImagePaths.ForEach(x=> Console.WriteLine(x.FileName));
        return Ok(fileDto.ImagePaths);
    }
}
