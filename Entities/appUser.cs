using System;

namespace API.Entities;

public class appUser : BaseEntity
{
    public string UserName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string? ImageUrl { get; set; } = null;
    public required byte[] PasswordHash { get; set; }
    public required byte[] PasswordSalt { get; set; }

    public Member? Member { get; set; } = null!;
}
