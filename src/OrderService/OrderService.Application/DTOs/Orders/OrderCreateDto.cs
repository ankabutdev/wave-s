namespace OrderService.Application.DTOs.Orders;

public class OrderCreateDto
{
    public int UserId { get; set; }

    public string Description { get; set; } = string.Empty;

    public int ProductId { get; set; }
}
