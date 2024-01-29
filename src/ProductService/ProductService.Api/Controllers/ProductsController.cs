using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using ProductService.Application.DTOs.Products;
using ProductService.Application.UseCases.Products.Commands.CreateProduct;
using ProductService.Application.UseCases.Products.Commands.DeleteProduct;
using ProductService.Application.UseCases.Products.Commands.UpdateProduct;
using ProductService.Application.UseCases.Products.Queries.GetAllProduct;
using ProductService.Application.UseCases.Products.Queries.GetByIdProduct;
using ProductService.Application.UseCases.Products.Queries.GetProductByCategoryId;
using ProductService.Application.UseCases.Products.Queries.GetProductByCategoryName;
using ProductService.Application.UseCases.Products.Queries.GetProductByCompanyId;
using ProductService.Domain.Entities;

namespace ProductService.Api.Controllers;

#pragma warning disable

[Route("api/products/")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;
    private readonly IMemoryCache _cache;
    private readonly ILogger _logger;
    private readonly IWebHostEnvironment _env;

    private readonly string ROOTHPATH;

    public ProductsController(IMediator mediator, IMapper mapper,
        IMemoryCache memoryCache, IWebHostEnvironment webHostEnvironment)
    {
        _mediator = mediator;
        _mapper = mapper;
        _cache = memoryCache;
        ROOTHPATH = webHostEnvironment.WebRootPath;
    }

    [HttpGet]
    public async ValueTask<IActionResult> GetAllAsync()
    {
        //var result = await _mediator.Send(new GetAllProductQuery());
        //return Ok(result);

        if (_cache.TryGetValue("AllProducts", out var cachedData))
        {
            IEnumerable<Product>? product = (IEnumerable<Product>)cachedData;
            Console.WriteLine("GET DATA CACHE MEMORY");
            return Ok(product);
        }

        var result = await _mediator.Send(new GetAllProductQuery());

        var cacheEntryOptions = new MemoryCacheEntryOptions
        {
            AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(1),
            SlidingExpiration = TimeSpan.FromSeconds(20)
        };

        _cache.Set("AllProducts", result, cacheEntryOptions);

        return Ok(result);
    }

    [HttpGet("categories/name/{categoryName}")]
    public async Task<IActionResult> GetProductsByCategoryNameAsync(string categoryName)
    {
        var result = await _mediator.Send(new GetProductByCategoryNameQuery()
        {
            CategoryName = categoryName
        });
        return Ok(result);
    }

    [HttpGet("categories/id/{categoryId}")]
    public async Task<IActionResult> GetProductsByCategoryId(int categoryId)
    {
        return Ok(await _mediator.Send(new GetProductByCategoryIdQuery()
        {
            CategoryId = categoryId
        }));
    }

    [HttpGet("companies/{companyId}")]
    public async ValueTask<IActionResult> GetProductsByCompanyId(int companyId)
    {
        return Ok(await _mediator
            .Send(new GetProductByCompanyIdQuery()
            { CompanyId = companyId }));
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

    //[HttpPost("file")]
    //public async Task<IActionResult> CreateAsync([FromForm] FIleDto fileDto)
    //{
    //    fileDto.ImagePaths.ForEach(x=> Console.WriteLine(x.FileName));
    //    return Ok(fileDto.ImagePaths);
    //}
}
