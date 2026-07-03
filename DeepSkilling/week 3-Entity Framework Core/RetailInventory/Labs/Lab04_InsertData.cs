using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RetailInventory.Data;
using RetailInventory.Models;

namespace RetailInventory.Labs;

public static class Lab04_InsertData
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

        if (await db.Categories.AnyAsync(c => c.Name == "Electronics"))
        {
            Console.WriteLine("Data already exists.");
            return;
        }

        var c = new Category
        {
            Name = "Electronics"
        };

        db.Categories.Add(c);
        await db.SaveChangesAsync();

        var p = new Product
        {
            Name = "Laptop",
            Price = 65000,
            Stock = 10,
            CategoryId = c.CategoryId
        };

        db.Products.Add(p);

        await db.SaveChangesAsync();

        Console.WriteLine("Data Inserted Successfully.");
    }
}