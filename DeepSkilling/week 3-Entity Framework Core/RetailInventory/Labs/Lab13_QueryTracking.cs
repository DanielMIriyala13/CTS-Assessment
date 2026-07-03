using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RetailInventory.Data;

namespace RetailInventory.Labs;

public static class Lab13_QueryTracking
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

        Console.WriteLine("Tracked Query");

        var tracked = await db.Products.FirstOrDefaultAsync();

        if (tracked != null)
            Console.WriteLine(tracked.Name);

        Console.WriteLine();

        Console.WriteLine("No Tracking Query");

        var noTracking = await db.Products
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (noTracking != null)
            Console.WriteLine(noTracking.Name);
    }
}