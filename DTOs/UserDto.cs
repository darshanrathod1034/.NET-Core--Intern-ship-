using System;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace API.DTOs;

public class UserDto
{
    [Required]
    public string Username { get; set; }
    [Required]
    public string Token { get; set; }  
    [Required]
    public string Email { get; set; }

}
