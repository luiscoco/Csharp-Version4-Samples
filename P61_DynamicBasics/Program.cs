using System;
using System.Dynamic;

class Program
{
    static void Main()
    {
        dynamic x = 10;
        Console.WriteLine("x + 5 = " + (x + 5));

        dynamic person = new ExpandoObject();
        person.Name = "Ana";
        person.SayHello = (Action)(() => Console.WriteLine("Hello, " + person.Name));
        person.SayHello();

        try
        {
            person.DoesNotExist();
        }
        catch (Microsoft.CSharp.RuntimeBinder.RuntimeBinderException ex)
        {
            Console.WriteLine("Binder error caught: " + ex.Message);
        }
    }
}
