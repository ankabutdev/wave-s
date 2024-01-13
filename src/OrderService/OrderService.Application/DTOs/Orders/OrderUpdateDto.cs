using System.Text.Json.Serialization;

namespace OrderService.Application.DTOs.Orders;

public class OrderUpdateDto
{
    [JsonIgnore]
    public int Id { get; set; }

    public int UserId { get; set; }

    public string Description { get; set; } = string.Empty;

    public int ProductId { get; set; }
}
