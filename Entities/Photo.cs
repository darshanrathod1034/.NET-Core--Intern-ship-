using System;

namespace API.Entities;

public class Photo : BaseEntity
{
    public string Url { get; set; } = string.Empty;
    
    public string PublicId { get; set; } = string.Empty;

    // navigational property to associate photo with a member
    public Member? Member { get; set; }=null!;

}
