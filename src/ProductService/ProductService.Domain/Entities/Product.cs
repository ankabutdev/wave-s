namespace ProductService.Domain.Entities;

public partial class Product
{
    public long Id { get; set; }

    public long CategoryId { get; set; }

    public string Name { get; set; } = null!;

    public string ImagePaths { get; set; } = null!;

    public double Price { get; set; }

    public string Description { get; set; } = null!;

    public long CompanyId { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public string Frame { get; set; } = null!;

    public string Mounted { get; set; } = null!;

    public string Screen { get; set; } = null!;

    public string Buttons { get; set; } = null!;

    public double Weight { get; set; }

    public string Backlight { get; set; } = null!;

    public string Type { get; set; } = null!;

    public string Foam { get; set; } = null!;

    public string Mum { get; set; } = null!;

    public string Smartpause { get; set; } = null!;

    public string Turbopressure { get; set; } = null!;

    public virtual Category Category { get; set; } = null!;

    public virtual Company Company { get; set; } = null!;
}
