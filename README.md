# C# 4.0 Features – Sample Projects

This repository demonstrates the language features introduced in **C# 4.0** (shipped with .NET Framework 4 / VS 2010).  
C# 4.0 focused on *interoperability* and *flexibility*: dynamic binding, named/optional parameters, generic variance, and easier COM interop.

---

## 🚀 Key Features & Mini‑Examples

### 1) `dynamic` – Dynamic binding at runtime
- **What it is**: The `dynamic` type defers member binding until runtime (via the DLR). This enables cleaner interop with dynamic languages and COM APIs (Office, etc.), and lets you write duck-typed code in C#.
- **Example**:
```csharp
dynamic x = "Hello";
Console.WriteLine(x.Length);   // bound at runtime

dynamic excel = Activator.CreateInstance(Type.GetTypeFromProgID("Excel.Application"));
excel.Visible = true;
excel.Workbooks.Add();
```

**Why it matters**: Interacting with COM or dynamic objects becomes terse and natural (no reflection or verbose marshaling).

---

### 2) Named and Optional Arguments
- **What it is**: Callers can specify arguments by *name* and omit parameters that have *default values*.
- **Example**:
```csharp
void Log(string message, int level = 1, bool timestamp = true) { /* ... */ }

Log("Started");                         // uses defaults
Log(level: 3, message: "Verbose");      // named arguments out of order
```
**Why it matters**: Clearer call sites, easier API evolution (add parameters with defaults without breaking callers).

---

### 3) Generic Variance (interfaces & delegates)
- **What it is**: Support for **covariance** (`out`) and **contravariance** (`in`) in interface and delegate type parameters.
- **Example**:
```csharp
IEnumerable<string> strings = new List<string>();
IEnumerable<object> objects = strings; // covariance (out T) allows this

Action<object> ao = o => Console.WriteLine(o);
Action<string>  asg = ao;              // contravariance (in T) allows this
```
**Why it matters**: More flexible assignment and API design for generics (e.g., LINQ, collections, delegates).

---

### 4) Easier COM Interop (No PIA, ref elision, indexers)
- **Embedded interop types (NoPIA)**: You can **embed interop types** in your assembly so users don’t need the full Primary Interop Assemblies installed.
- **`ref`/`out` elision for COM**: Many COM calls no longer require explicit `ref`/`out` at call sites.
- **COM indexers & properties**: Work more naturally, especially when combined with `dynamic`.
- **Example** (illustrative Excel automation):
```csharp
dynamic excel = Activator.CreateInstance(Type.GetTypeFromProgID("Excel.Application"));
excel.Visible = true;
dynamic book = excel.Workbooks.Add();
dynamic sheet = book.ActiveSheet;
sheet.Cells[1, 1].Value = "Hello from C# 4.0";
```
**Why it matters**: Cleaner, version-resilient Office/COM automation without heavy interop assemblies or awkward syntax.

---

### 5) Optional Parameters + `params` + Named args together
- **What it is**: You can combine optional parameters with `params` and named arguments for very flexible APIs.
- **Example**:
```csharp
void Notify(string title, string body = "", params string[] tags)
{
    Console.WriteLine($"{title}: {body} [{string.Join(",", tags)}]");
}

Notify("Build");                         // body defaulted, no tags
Notify("Deploy", tags: new[] { "prod" });
Notify(body: "Done", title: "CI", tags: "ok", "fast");
```

---

## ▶ Build & Run

From the repo root:
```bash
dotnet restore
dotnet build
dotnet run --project <ProjectFolderName>
```
*(Open any sample project folder—each one is a small console app showing one of the features above.)*

---

## ✅ Tips & Notes

- Prefer `dynamic` only when necessary (COM, dynamic sources). For regular code, static typing gives better tooling and safety.
- Named/optional parameters are part of the *call site*; changing parameter names can be a breaking change for callers that use named args.
- With variance, remember: **out = returns**, **in = inputs** (i.e., you can *output* `out T`, and *input* `in T`).

---

## 📖 References (for deeper reading)

- C# 4.0 language specification highlights (dynamic binding, optional/named arguments, variance)  
- MSDN / Learn docs on **No-PIA** (Embedded Interop Types) and COM interop improvements  
