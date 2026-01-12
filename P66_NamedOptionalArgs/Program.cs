using System;

class Logger
{
    public static void Log(string message, string category = "Info", int severity = 1)
    {
        Console.WriteLine("[" + category + " " + severity + "] " + message);
    }
}

class Program
{
    static void Main()
    {
        Logger.Log("Started");
        Logger.Log(category: "Debug", message: "Step", severity: 2);
        Logger.Log(message: "Only severity changed", severity: 5);
    }
}
