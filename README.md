# C# 4.0 Features – Sample Projects

This repository demonstrates the language features introduced in **C# version 4.0** (Visual Studio 2010 / .NET Framework 4).  
C# 4.0 focused on interop, flexibility, and variance: the `dynamic` type, named/optional parameters, generic variance, and improved overload resolution.

Projects included:
- `P65_DynamicBasics`
- `P66_NamedOptionalArgs`
- `P67_GenericVariance_Interfaces`
- `P68_DynamicOverloadResolution`
- `P69_DynamicWithReflectionLike`
- `P70_DelegatesVariance`
- `P71_NamedArgsOverloadResolution`

---

## 🚀 Features & Samples

### P65_DynamicBasics
**Feature**: `dynamic` type – late binding at runtime.
```csharp
dynamic x = "hello";
Console.WriteLine(x.Length);   // resolved at runtime

x = 123;
Console.WriteLine(x + 5);      // int addition at runtime
```
**Purpose**: Avoids reflection boilerplate; useful for COM and runtime-constructed types.

---

### P66_NamedOptionalArgs
**Feature**: Named and optional arguments.
```csharp
void Print(string msg, int level = 1, bool timestamp = true)
{
    Console.WriteLine($"{(timestamp ? DateTime.Now : "")}[{level}] {msg}");
}

Print("Hello");                        // uses defaults
Print(level: 3, msg: "Error", timestamp: false); // named, out of order
```
**Purpose**: More flexible, self-documenting method calls.

---

### P67_GenericVariance_Interfaces
**Feature**: Covariance (`out`) and contravariance (`in`) in generic interfaces.
```csharp
IEnumerable<string> words = new List<string> { "one", "two" };
IEnumerable<object> objs = words; // covariance

Action<object> log = o => Console.WriteLine(o);
Action<string> logStr = log;       // contravariance
logStr("Hi");
```
**Purpose**: Flexible assignments for collections and delegates.

---

### P68_DynamicOverloadResolution
**Feature**: Overload resolution with `dynamic` at runtime.
```csharp
void Foo(int x)    => Console.WriteLine("int");
void Foo(string s) => Console.WriteLine("string");

dynamic d = 5;
Foo(d);   // Foo(int) at runtime
d = "hi";
Foo(d);   // Foo(string) at runtime
```
**Purpose**: Demonstrates runtime dispatch of method overloads.

---

### P69_DynamicWithReflectionLike
**Feature**: Using `dynamic` instead of reflection.
```csharp
dynamic obj = new { Name = "Alice", Age = 30 };
Console.WriteLine(obj.Name); // late-bound, no compile-time type info
```
**Purpose**: Simplifies late-bound scenarios.

---

### P70_DelegatesVariance
**Feature**: Variance for delegates.
```csharp
Func<string> getStr = () => "hello";
Func<object> getObj = getStr; // covariance

Action<object> actObj = o => Console.WriteLine(o);
Action<string> actStr = actObj; // contravariance
```
**Purpose**: Greater flexibility in assigning delegates.

---

### P71_NamedArgsOverloadResolution
**Feature**: Named arguments in overload resolution.
```csharp
void Foo(int x, string y) => Console.WriteLine("int,string");
void Foo(string y, int x) => Console.WriteLine("string,int");

Foo(1, "hi");                 // Foo(int,string)
Foo(y: "hi", x: 1);           // named args disambiguate
Foo(x: 1, y: "hi");           // explicit clarity
```
**Purpose**: Helps disambiguate between overloads and improves readability.

---

## Build & Run

From the repo root:
```bash
dotnet restore
dotnet build
dotnet run --project P61_DynamicBasics
# Or run another project, e.g. P62_NamedOptionalArgs, etc.
```

---

## Summary

C# 4.0 brought:
- `dynamic` for runtime binding (great for COM interop).  
- Named and optional parameters for cleaner, evolving APIs.  
- Variance (`in` / `out`) for interfaces and delegates.  
- Smarter overload resolution with dynamic and named args.  

