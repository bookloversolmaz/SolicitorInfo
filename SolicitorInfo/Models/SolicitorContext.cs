using Microsoft.EntityFrameworkCore;

namespace SolicitorInfo.Models;

public class SolicitorContext : DbContext
{
    public SolicitorContext(DbContextOptions<SolicitorContext> options)
        : base(options)
    {
    }

    public DbSet<SolicitorItem> SolicitorItems { get; set; } = null!;
}