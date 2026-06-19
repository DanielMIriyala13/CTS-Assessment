using System;
using System.Collections.Generic;

class Program
{
	static void Main()
	{
		LinkedList<int> l = new LinkedList<int>();
		l.AddLast(10);
		l.AddLast(20);
		l.AddLast(30);
		// Simple linked list
		foreach (int x in l)
		{
			Console.WriteLine(x);
		}
	}
}
