using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entities;

public class Member : BaseEntity
{
    public required string Name { get; set; } = string.Empty; 
    public int Age { get; set; }
    public  DateOnly DOB { get; set; }
    public string? ImageUrl { get; set; } = null;
    public string? Discription { get; set; } = null;
    public string? Address { get; set; } = null;
    public required string Gender { get; set; }

    [ForeignKey(nameof(Id))]
    public appUser? AppUser { get; set; } = null!;   


}
