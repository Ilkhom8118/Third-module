using Furniture.DataAccess.Entity;
using Microsoft.EntityFrameworkCore;

namespace Furniture.DataAccess;

public class MainContext : DbContext
{
    public DbSet<Furnitures> Furniture { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=DESKTOP-JA0B9SA\\SQLEXPRESS;Database=Furniture;User Id=sa;Password=1;TrustServerCertificate=True;");
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}
