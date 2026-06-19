using System;

class Program
{
	static void Main()
	{
		int[] a = { 10, 20, 30, 40, 50 };
		int t = 40;
		int l = 0, h = a.Length - 1;
		int p = -1;
		// Binary search
		while (l <= h)
		{
			int m = l + (h - l) / 2;
			if (a[m] == t)
			{
				p = m;
				break;
			}
			if (a[m] < t)
				l = m + 1;
			else
				h = m - 1;
		}
		if (p != -1)
			Console.WriteLine("Element Found at index: " + p);
		else
			Console.WriteLine("Element Not Found");
	}
}
