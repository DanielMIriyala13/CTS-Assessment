using System;

class Old
{
	public void Work()
	{
		Console.WriteLine("Old Method");
	}
}

class Adapter
{
	Old o=new Old();
	public void Run()
	{
		o.Work();
	}
}

class Program
{
	static void Main()
	{
		//Adapter connects old class
		Adapter a=new Adapter();
		a.Run();
	}
}