using System;

interface IMsg
{
	void Send();
}

class Email:IMsg
{
	public void Send()
	{
		Console.WriteLine("Email Sent");
	}
}

class Notify
{
	IMsg m;
	public Notify(IMsg x)
	{
		m=x;
	}
	public void Send()
	{
		m.Send();
	}
}

class Program
{
	static void Main()
	{
		//Depends on interface not class
		Notify n=new Notify(new Email());
		n.Send();
	}
}