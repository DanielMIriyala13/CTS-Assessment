using System;

interface IPrint
{
	void Print();
}

interface IScan
{
	void Scan();
}

class Machine:IPrint,IScan
{
	public void Print()
	{
		Console.WriteLine("Printing");
	}
	public void Scan()
	{
		Console.WriteLine("Scanning");
	}
}

class Program
{
	static void Main()
	{
		//Only required interfaces are implemented
		Machine m=new Machine();
		m.Print();
		m.Scan();
	}
}