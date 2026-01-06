using System;

namespace API.Entities;

public class appUser
{
    public int Id { get; set; }
    public string UserName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public required byte[] PasswordHash { get; set; }
    public required byte[] PasswordSalt { get; set; }
}
