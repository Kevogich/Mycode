using System;
///Summary
///this example shows how to use interface in C#
///Summary
interface IMyInterface
{
    // 接口成员
    void MethodToImplement();
	void MethodToImplement1();
	void MethodToImplement2();
}

class InterfaceImplementer : IMyInterface
{
    static void Main()
    {
		NewMethod();
        InterfaceImplementer iImp = new InterfaceImplementer();
        iImp.MethodToImplement();
		iImp.MethodToImplement2();
		iImp.MethodToImplement1();
    }

    public void MethodToImplement()
    {
        Console.WriteLine("MethodToImplement() called.");
    }
	    public void MethodToImplement1()
    {
        Console.WriteLine("MethodToImplement() called.");
    }
	    public void MethodToImplement2()
    {
        Console.WriteLine("MethodToImplement() called.");
    }
	
	    private static void NewMethod()
        {
            Console.WriteLine("Hello Worl1d!");
        }
}