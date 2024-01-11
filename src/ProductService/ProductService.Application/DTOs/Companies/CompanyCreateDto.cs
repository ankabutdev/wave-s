using System.Text.Json.Serialization;

namespace ProductService.Application.DTOs.Companies;

public class CompanyCreateDto
{
    [JsonIgnore]
    public int Id { get; set; }

    public string Description { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string CompanyPhoneNumber { get; set; } = null!;

    public string Email { get; set; } = null!;
}
