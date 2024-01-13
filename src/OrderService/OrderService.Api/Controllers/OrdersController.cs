using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using OrderService.Application.DTOs.Orders;
using OrderService.Application.UseCases.Orders.Commands.CreateOrder;
using OrderService.Application.UseCases.Orders.Commands.DeleteOrder;
using OrderService.Application.UseCases.Orders.Commands.UpdateOrder;
using OrderService.Application.UseCases.Orders.Queries.GetAllOrder;
using OrderService.Application.UseCases.Orders.Queries.GetByIdOrder;

namespace OrderService.Api.Controllers;

[Route("api/orders")]
[ApiController]
public class OrdersController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public OrdersController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpGet]
    public async ValueTask<IActionResult> GetAllAsync()
    {
        return Ok(await _mediator.Send(new GetAllOrderQuery()));
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
