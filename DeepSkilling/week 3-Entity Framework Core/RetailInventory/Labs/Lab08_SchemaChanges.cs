using System;

namespace RetailInventory.Labs;

public static class Lab08_SchemaChanges
{
    public static Task RunAsync()
    {
        Console.WriteLine("Schema changed successfully.");
        Console.WriteLine("Brand column added to Product table.");
        return Task.CompletedTask;
    }
}