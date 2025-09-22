using System;

class Overloads
{
    public static string M(int x) { return "int"; }
    public static string M(double x) { return "double"; }
}

class Program
{
    static void Main()
    {
        Console.WriteLine(Overloads.M(5));
        Console.WriteLine(Overloads.M(5.0));

        dynamic d = 5;
        Console.WriteLine(Overloads.M(d));

        d = 5.0;
        Console.WriteLine(Overloads.M(d));
    }
}
