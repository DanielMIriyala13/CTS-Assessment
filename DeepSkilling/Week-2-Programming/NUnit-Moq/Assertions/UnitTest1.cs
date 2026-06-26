using NUnit.Framework;

namespace Assertions;

public class Tests
{
	[Test]
	public void Test1()
	{
		Assert.AreEqual(10,5+5);
		Assert.IsTrue(10>5);
		Assert.IsFalse(5>10);
		Assert.IsNotNull("CTS");
	}
}