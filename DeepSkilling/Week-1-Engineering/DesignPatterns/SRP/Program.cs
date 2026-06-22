using System;

//SRP means one class should do only one work

class Inv{
	public int tot(int p,int q){
		return p*q;
	}
}

class Prt{
	public void pr(int t){
		Console.WriteLine("Total:"+t);
	}
}

class P{
	static void Main(){
		Inv i=new Inv();
		int t=i.tot(100,2);

		Prt p=new Prt();
		p.pr(t);
	}
}

//here calculation nd printing are separated