using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RetailInventory.Data;

namespace RetailInventory.Labs;

public static class Lab06_UpdateDelete
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

        // UPDATE
        var product = await db.Products.FirstOrDefaultAsync();

        if (product != null)
        {
            product.Stock = 20;

            await db.SaveChangesAsync();

            Console.WriteLine("Product Updated Successfully.");
        }
        else
        {
            Console.WriteLine("No product found to update.");
            return;
        }

        // DELETE
        db.Products.Remove(product);

        await db.SaveChangesAsync();

        Console.WriteLine("Product Deleted Successfully.");
    }
}