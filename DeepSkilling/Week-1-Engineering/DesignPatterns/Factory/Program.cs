using System;

interface ICar
{
	void Run();
}

class Bmw:ICar
{
	public void Run()
	{
		Console.WriteLine("BMW Running");
	}
}

class Audi:ICar
{
	public void Run()
	{
		Console.WriteLine("Audi Running");
	}
}

class Car
{
	public static ICar Get(string s)
	{
		if(s=="BMW")
			return new Bmw();
		return new Audi();
	}
}

class Program
{
	static void Main()
	{
		//Factory creates required object
		ICar c=Car.Get("BMW");
		c.Run();
	}
}