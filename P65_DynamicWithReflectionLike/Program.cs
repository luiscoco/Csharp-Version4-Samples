using System;
using System.Dynamic;

class Duck : DynamicObject
{
    public override bool TryInvokeMember(InvokeMemberBinder binder, object[] args, out object result)
    {
        if (binder.Name == "Quack")
        {
            result = "Quack! " + (args.Length > 0 ? args[0] : "");
            return true;
        }
        result = null;
        return false;
    }
}

class Program
{
    static void Main()
    {
        dynamic duck = new Duck();
        Console.WriteLine(duck.Quack("loudly"));
        try
        {
            Console.WriteLine(duck.Fly());
        }
        catch (Microsoft.CSharp.RuntimeBinder.RuntimeBinderException ex)
        {
            Console.WriteLine("Runtime binder failed: " + ex.Message);
        }
    }
}
