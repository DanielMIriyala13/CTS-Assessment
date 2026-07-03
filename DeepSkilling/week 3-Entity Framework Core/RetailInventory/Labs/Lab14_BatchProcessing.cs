using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RetailInventory.Data;
using RetailInventory.Models;

namespace RetailInventory.Labs;

public static class Lab14_BatchProcessing
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

        db.Products.AddRange(

            new Product
            {
                Name="Mouse",
                Price=700,
                Stock=50,
                Brand="Logitech",
                CategoryId=1
            },

            new Product
            {
                Name="Keyboard",
                Price=1200,
                Stock=40,
                Brand="HP",
                CategoryId=1
            }

        );

        await db.SaveChangesAsync();

        Console.WriteLine("Batch Insert Completed.");

        var products = await db.Products.ToListAsync();

        foreach (var p in products)
        {
            p.Stock += 5;
        }

        await db.SaveChangesAsync();

        Console.WriteLine("Batch Update Completed.");
    }
}