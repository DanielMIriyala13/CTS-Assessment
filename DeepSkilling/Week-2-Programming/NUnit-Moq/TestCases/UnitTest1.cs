using NUnit.Framework;

namespace TestCases;

public class Tests
{
	[TestCase(2,3,5)]
	[TestCase(5,5,10)]
	[TestCase(10,20,30)]
	public void Add(int a,int b,int c)
	{
		Assert.AreEqual(c,a+b);
	}
}