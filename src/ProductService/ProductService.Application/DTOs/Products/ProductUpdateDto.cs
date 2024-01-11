using System.Text.Json.Serialization;

namespace ProductService.Application.DTOs.Products;

public class ProductUpdateDto
{
    [JsonIgnore]
    public int Id { get; set; }

    public int CategoryId { get; set; }

    public string Name { get; set; } = null!;

    public string ImagePaths { get; set; } = null!;

    public double Price { get; set; }

    public string Description { get; set; } = null!;

    public int CompanyId { get; set; }

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
}
