using System.Text.Json.Serialization;

namespace ProductService.Application.DTOs.Companies;

public class CompanyUpdateDto
{
    [JsonIgnore]
    public long Id { get; set; }

    public string Description { get; set; } = string.Empty;

    public string Name { get; set; } = string.Empty;

    public string CompanyPhoneNumber { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;
}
