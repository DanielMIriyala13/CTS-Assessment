using Microsoft.EntityFrameworkCore;
using RetailInventoryAPI.Models;

namespace RetailInventoryAPI.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Product> Products => Set<Product>();

    public DbSet<Category> Categories => Set<Category>();
}