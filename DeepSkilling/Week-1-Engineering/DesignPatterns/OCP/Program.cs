using System;

//OCP means it will add new feature without changing old code
abstract class Pay{
	public abstract void doPay();
}

class Card:Pay{
	public override void doPay(){
		Console.WriteLine("Card");
	}
}

class Upi:Pay{
	public override void doPay(){
		Console.WriteLine("UPI");
	}
}

class P{
	static void Main(){
		Pay p=new Card();
		p.doPay();
	}
}
//can add new payment types easily