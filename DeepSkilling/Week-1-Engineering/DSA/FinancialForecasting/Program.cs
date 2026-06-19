using System;

class Program
{
	static double Forecast(double v, double r, int y)
	{
		if (y == 0) return v;
		return Forecast(v * (1 + r), r, y - 1);
	}

	static void Main()
	{
		// Predict growth
		double res = Forecast(1000, 0.05, 3);
		Console.WriteLine("Value: " + res);
	}
}
