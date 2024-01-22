using System.ComponentModel.DataAnnotations;

namespace UserService.Application.DTOs.Users;

public class UserCreateDto
{
    public string FullName { get; set; } = string.Empty;

    [Phone]
    public string PhoneNumber { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

}
