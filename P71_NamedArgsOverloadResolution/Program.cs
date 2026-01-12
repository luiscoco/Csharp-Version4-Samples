using System;

class Demo
{
    static void F(int x, int y = 1) { Console.WriteLine("F(int,int) x="+x+", y="+y); }
    static void F(double x) { Console.WriteLine("F(double) x="+x); }

    static void Main()
    {
        F(x: 5);  // picks F(int,int) using default y
        F(5.0);   // picks F(double)
    }
}
