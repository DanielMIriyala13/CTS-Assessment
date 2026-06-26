using NUnit.Framework;
using Moq;

namespace MoqBasics;

public interface IMsg
{
	string Get();
}

public class Tests
{
	[Test]
	public void Test1()
	{
		var m=new Mock<IMsg>();
		m.Setup(x=>x.Get()).Returns("Hello");
		Assert.AreEqual("Hello",m.Object.Get());
	}
}