using NUnit.Framework;

namespace SetupAndTeardown;

public class Tests
{
	[SetUp]
	public void S()
	{
		TestContext.WriteLine("Setup");
	}

	[TearDown]
	public void T()
	{
		TestContext.WriteLine("TearDown");
	}

	[Test]
	public void Test1()
	{
		Assert.Pass();
	}
}