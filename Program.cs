using System;

namespace Test2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            UnitCon UC = new UnitCon();
            UC.i =25;
            UC.Unit1 = @"SG(Gas)";
            UC.Unit2 = @"Kg/m3";
            double printout = UC.Value2(UC.i);
            Console.WriteLine(printout);

        }
    }
}

//chang the date 