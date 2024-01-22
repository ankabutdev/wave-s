using System.Text.Json.Serialization;

namespace UserService.Application.DTOs.Users;

public class UserUpdateDto
{
    [JsonIgnore]
    public int Id { get; set; }

    public string FullName { get; set; } = string.Empty;

    public string PhoneNumber { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

}
