using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RetailInventory.Data;

namespace RetailInventory.Labs;

public static class Lab07_LINQQueries
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

        Console.WriteLine("===== All Products =====");

        var products = await db.Products.ToListAsync();

        foreach (var p in products)
        {
            Console.WriteLine($"{p.ProductId} {p.Name} {p.Price}");
        }

        Console.WriteLine("\n===== Price > 50000 =====");

        var expensive = await db.Products
            .Where(p => p.Price > 50000)
            .ToListAsync();

        foreach (var p in expensive)
        {
            Console.WriteLine($"{p.Name} {p.Price}");
        }

        Console.WriteLine("\n===== Order By Name =====");

        var ordered = await db.Products
            .OrderBy(p => p.Name)
            .ToListAsync();

        foreach (var p in ordered)
        {
            Console.WriteLine($"{p.Name}");
        }

        Console.WriteLine("\n===== First Product =====");

        var first = await db.Products.FirstOrDefaultAsync();

        if (first != null)
            Console.WriteLine(first.Name);

        Console.WriteLine($"\nTotal Products : {await db.Products.CountAsync()}");

        Console.WriteLine($"Any Products : {await db.Products.AnyAsync()}");
    }
}