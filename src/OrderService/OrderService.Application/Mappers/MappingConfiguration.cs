using AutoMapper;
using OrderService.Application.DTOs.Orders;
using OrderService.Application.UseCases.Orders.Commands.CreateOrder;
using OrderService.Application.UseCases.Orders.Commands.UpdateOrder;
using OrderService.Domain.Entities;

namespace OrderService.Application.Mappers;

public class MappingConfiguration : Profile
{
    public MappingConfiguration()
    {
        // Orders
        CreateMap<Order, OrderCreateDto>().ReverseMap();
        CreateMap<Order, OrderUpdateDto>().ReverseMap();

        CreateMap<Order, CreateOrderCommand>().ReverseMap();
        CreateMap<Order, OrderUpdateCommand>().ReverseMap();

        CreateMap<OrderCreateDto, CreateOrderCommand>().ReverseMap();
        CreateMap<OrderUpdateDto, OrderUpdateCommand>().ReverseMap();
    }
}
