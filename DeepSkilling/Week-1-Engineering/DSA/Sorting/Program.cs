using System;

class Program
{
	static void Main()
	{
		int[] a = { 50, 20, 40, 10, 30 };
		// Bubble sort
		for (int i = 0; i < a.Length - 1; i++)
		{
			for (int j = 0; j < a.Length - i - 1; j++)
			{
				if (a[j] > a[j + 1])
				{
					int t = a[j];
					a[j] = a[j + 1];
					a[j + 1] = t;
				}
			}
		}
		for (int i = 0; i < a.Length; i++)
		{
			Console.WriteLine(a[i]);
		}
	}
}
