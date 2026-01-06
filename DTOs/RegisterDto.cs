namespace API.DTOs;
using System.ComponentModel.DataAnnotations;


public class RegisterDto
{
    [Required(ErrorMessage = "Username is required")]
    public string Username { get; set; } = string.Empty;
    [Required(ErrorMessage = "Password is required")]
    [MinLength(5, ErrorMessage = "Password must be at least 8 characters long")]
    public string Password { get; set; } = string.Empty;
    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Invalid email address")]
    [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Invalid email address")]
    public string Email { get; set; } = string.Empty;
}

