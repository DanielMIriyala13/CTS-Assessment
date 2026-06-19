using System;

class Product
{
	public int Id { get; set; }
	public string Name { get; set; }
}

class Program
{
	static void Main()
	{
		Product[] p = new Product[]
		{
			new Product { Id = 101, Name = "Laptop" },
			new Product { Id = 102, Name = "Phone" },
			new Product { Id = 103, Name = "Tablet" },
			new Product { Id = 104, Name = "Watch" }
		};
		int k = 103;
		bool f = false;
		// Search product by ID
		for (int i = 0; i < p.Length; i++)
		{
			if (p[i].Id == k)
			{
				Console.WriteLine("Product Found: " + p[i].Name);
				f = true;
				break;
			}
		}
		if (!f)
		{
			Console.WriteLine("Product Not Found");
		}
	}
}
