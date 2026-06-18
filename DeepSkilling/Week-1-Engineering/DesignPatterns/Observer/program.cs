using System;

class User
{
	public void Update()
	{
		Console.WriteLine("Notification Received");
	}
}

class News
{
	User u=new User();
	public void Send()
	{
		u.Update();
	}
}

class Program
{
	static void Main()
	{
		//Observer gets notification
		News n=new News();
		n.Send();
	}
}