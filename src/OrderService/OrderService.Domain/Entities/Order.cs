namespace OrderService.Domain.Entities;

public class Order
{
    public int Id { get; set; }

    public decimal UserId { get; set; }

    public string Description { get; set; } = string.Empty;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public DateTime UpdatedAt { get; set; }

    public int ProductId { get; set; }
}
