using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RetailInventory.Data;

namespace RetailInventory.Labs;

public static class Lab05_RetrieveData
{
    public static async Task RunAsync()
    {
        var config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();

        var cs = config.GetConnectionString("DefaultConnection");

        var services = new ServiceCollection();

        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(cs));

        using var provider = services.BuildServiceProvider();
        using var db = provider.GetRequiredService<AppDbContext>();

        Console.WriteLine("===== Categories =====");

        var categories = await db.Categories.ToListAsync();

        foreach (var category in categories)
        {
            Console.WriteLine($"{category.CategoryId}\t{category.Name}");
        }

        Console.WriteLine();

        Console.WriteLine("===== Products =====");

        var products = await db.Products.ToListAsync();

        foreach (var product in products)
        {
            Console.WriteLine($"{product.ProductId}\t{product.Name}\t{product.Price}\t{product.Stock}\t{product.CategoryId}");
        }
    }
}