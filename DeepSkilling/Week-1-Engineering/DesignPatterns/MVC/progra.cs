using System;

class Model
{
	public string n="Daniel";
}

class View
{
	public void Show(string s)
	{
		Console.WriteLine(s);
	}
}

class Controller
{
	Model m=new Model();
	View v=new View();
	public void Run()
	{
		v.Show(m.n);
	}
}

class Program
{
	static void Main()
	{
		//Controller connects model and view
		Controller c=new Controller();
		c.Run();
	}
}