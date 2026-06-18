using System;

class Db
{
	static Db o;
	private Db(){}
	public static Db Get()
	{
		if(o==null)
			o=new Db();
		return o;
	}
	public void Show()
	{
		Console.WriteLine("Single Object Created");
	}
}

class Program
{
	static void Main()
	{
		//Only one object is created
		Db d=Db.Get();
		d.Show();
	}
}