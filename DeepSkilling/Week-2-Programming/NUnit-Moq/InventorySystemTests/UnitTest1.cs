using NUnit.Framework;

namespace InventorySystemTests;

public class Item
{
	public int Qty=10;
}

public class Tests
{
	[Test]
	public void Test1()
	{
		Item i=new Item();
		Assert.AreEqual(10,i.Qty);
	}
}