using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RetailInventory.Data;

namespace RetailInventory.Labs;

public static class Lab12_CircularReferences
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

        Console.WriteLine("===== Circular Reference Demo =====");

        var categories = await db.Categories
            .Include(c => c.Products)
            .ToListAsync();

        foreach (var category in categories)
        {
            Console.WriteLine($"\nCategory : {category.Name}");

            foreach (var product in category.Products)
            {
                Console.WriteLine($"   Product : {product.Name}");
                Console.WriteLine($"   Category : {category.Name}");
            }
        }

        Console.WriteLine();
        Console.WriteLine("Navigation Properties:");
        Console.WriteLine("Category -> Products");
        Console.WriteLine("Product -> Category");
        Console.WriteLine();
        Console.WriteLine("These two-way navigation properties can create circular references during JSON serialization.");
        Console.WriteLine("ASP.NET Core solves this using ReferenceHandler.IgnoreCycles or DTOs.");
    }
}