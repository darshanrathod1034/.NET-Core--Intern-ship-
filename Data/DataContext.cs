using Microsoft.EntityFrameworkCore;
using API.Entities;

namespace API.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    public DbSet<appUser> Users { get; set; }
}

