using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RetailInventory.Data;

namespace RetailInventory.Labs;

public static class Lab10_LoadingStrategies
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

        Console.WriteLine("===== Eager Loading =====");

        var products = await db.Products
            .Include(p => p.Category)
            .ToListAsync();

        foreach (var p in products)
        {
            Console.WriteLine($"{p.Name}  ->  {p.Category?.Name}");
        }
    }
}