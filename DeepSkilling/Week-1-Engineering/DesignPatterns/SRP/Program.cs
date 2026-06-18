using System;

class Report
{
	public void Create()
	{
		Console.WriteLine("Report Created");
	}
}

class Print
{
	public void Show()
	{
		Console.WriteLine("Report Printed");
	}
}

class Program
{
	static void Main()
	{
		//One class creates report
		Report r=new Report();
		r.Create();
		//Another class prints report
		Print p=new Print();
		p.Show();
	}
}