using NUnit.Framework;
using Moq;

namespace MockingInterfaces;

public interface IData
{
	int GetId();
}

public class Tests
{
	[Test]
	public void Test1()
	{
		var m=new Mock<IData>();
		m.Setup(x=>x.GetId()).Returns(101);
		Assert.AreEqual(101,m.Object.GetId());
	}
}