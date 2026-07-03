using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RetailInventory.Data;
using RetailInventory.Models;

namespace RetailInventory.Labs;

public static class Lab11_Relationships
{
    public static async Task RunAsync()
    {
        var config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();

        var cs = config.GetConnectionString("DefaultConnection");

        var services = new ServiceCollection();

        services.AddDbContext<AppDbContext>(o =>
            o.UseSqlServer(cs));

        using var provider = services.BuildServiceProvider();

        using var db = provider.GetRequiredService<AppDbContext>();

        var category = new Category
        {
            Name = "Mobiles"
        };

        db.Categories.Add(category);

        await db.SaveChangesAsync();

        db.Products.Add(new Product
        {
            Name = "iPhone",
            Price = 85000,
            Stock = 5,
            Brand = "Apple",
            CategoryId = category.CategoryId
        });

        db.Products.Add(new Product
        {
            Name = "Galaxy S25",
            Price = 78000,
            Stock = 8,
            Brand = "Samsung",
            CategoryId = category.CategoryId
        });

        await db.SaveChangesAsync();

        var categories = await db.Categories
            .Include(c => c.Products)
            .ToListAsync();

        foreach (var c in categories)
        {
            Console.WriteLine($"\nCategory : {c.Name}");

            foreach (var p in c.Products)
            {
                Console.WriteLine($"   {p.Name}");
            }
        }
    }
}