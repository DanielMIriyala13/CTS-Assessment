using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RetailInventory.Data;

namespace RetailInventory.Labs;

public static class Lab15_Concurrency
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

        Console.WriteLine("===== Concurrency Demo =====");

        var product = await db.Products.FirstOrDefaultAsync();

        if (product == null)
        {
            Console.WriteLine("No Product Available.");
            return;
        }

        Console.WriteLine($"Before Update : {product.Name}  Stock = {product.Stock}");

        product.Stock += 1;

        try
        {
            await db.SaveChangesAsync();

            Console.WriteLine("Update Successful.");
            Console.WriteLine($"After Update : Stock = {product.Stock}");
            Console.WriteLine("No Concurrency Conflict Detected.");
        }
        catch (DbUpdateConcurrencyException)
        {
            Console.WriteLine("Concurrency Conflict Occurred.");
        }
    }
}