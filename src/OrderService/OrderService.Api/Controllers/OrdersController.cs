using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using OrderService.Application.DTOs.Orders;
using OrderService.Application.UseCases.Orders.Commands.CreateOrder;
using OrderService.Application.UseCases.Orders.Commands.DeleteOrder;
using OrderService.Application.UseCases.Orders.Commands.UpdateOrder;
using OrderService.Application.UseCases.Orders.Queries.GetAllOrder;
using OrderService.Application.UseCases.Orders.Queries.GetByIdOrder;
using OrderService.Domain.Entities;

namespace OrderService.Api.Controllers;

#pragma warning disable

[Route("api/orders")]
[ApiController]
public class OrdersController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;
    private readonly IMemoryCache _cache;

    public OrdersController(IMediator mediator, IMapper mapper,
        IMemoryCache cache)
    {
        _mediator = mediator;
        _mapper = mapper;
        _cache = cache;
    }

    [HttpGet]
    public async ValueTask<IActionResult> GetAllAsync()
    {
        if (_cache.TryGetValue("AllOrders", out var cachedData))
        {
            IEnumerable<Order>? product = (IEnumerable<Order>)cachedData;
            Console.WriteLine("GET DATA CACHE MEMORY");
            return Ok(product);
        }

        var result = await _mediator.Send(new GetAllOrderQuery());

        var cacheEntryOptions = new MemoryCacheEntryOptions
        {
            AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(1),
            SlidingExpiration = TimeSpan.FromSeconds(20)
        };

        _cache.Set("AllOrders", result, cacheEntryOptions);

        return Ok(result);
    }

    [HttpGet("{Id}")]
    public async ValueTask<IActionResult> GetByIdAsync(int Id)
    {
        var result = await _mediator
            .Send(new GetByIdOrderQuery { Id = Id });

        return Ok(result);
    }

    [HttpPost]
    public async ValueTask<IActionResult> CreateAsync(OrderCreateDto dto)
    {
        var category = _mapper.Map<CreateOrderCommand>(dto);

        var result = await _mediator.Send(category);

        return Ok(result);
    }

    [HttpPut("{Id}")]
    public async Task<IActionResult> UpdateAsync(int Id, OrderUpdateDto dto)
    {
        var category = _mapper.Map<OrderUpdateCommand>(dto);
        category.Id = Id;
        var result = await _mediator.Send(category);
        return Ok(result);
    }

    [HttpDelete("{Id}")]
    public async Task<IActionResult> DeleteAsync(int Id)
    {
        var result = await _mediator
            .Send(new OrderDeleteCommand() { Id = Id });

        return Ok(result);
    }
}
