using System;

abstract class Shape
{
	public abstract void Area();
}

class Circle:Shape
{
	public override void Area()
	{
		Console.WriteLine("Area of Circle");
	}
}

class Rect:Shape
{
	public override void Area()
	{
		Console.WriteLine("Area of Rectangle");
	}
}

class Program
{
	static void Main()
	{
		//New shapes can be added without changing old code
		Shape s=new Circle();
		s.Area();
		s=new Rect();
		s.Area();
	}
}