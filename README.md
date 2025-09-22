# C# 4.0 Features (Visual Studio 2010, .NET 4)

This solution demonstrates **key features introduced in C# 4.0**.

## Projects
- **P61_DynamicBasics** — `dynamic` keyword, `ExpandoObject`, runtime binder errors.
- **P62_NamedOptionalArgs** — Named arguments and optional parameters (defaults).
- **P63_GenericVariance_Interfaces** — Covariance (`out`) and contravariance (`in`) on interfaces like `IEnumerable<T>`, `IComparer<T>`.
- **P64_DynamicOverloadResolution** — Dynamic controls overload selection at runtime.
- **P65_DynamicWithReflectionLike** — Custom `DynamicObject` implementing late-bound methods.
- **P66_DelegatesVariance** — Variance on delegates (`Func<out T>`, `Action<in T>`).
- **P67_NamedArgsOverloadResolution** — How named/optional args influence overload resolution.

> Note on **COM interop** and **No-PIA (Embedded Interop Types)**: those are compiler/interop features best shown with an actual COM reference (e.g., Office). This repo focuses on the language facets (`dynamic`, named/optional, variance).

## Build & Run
```bash
dotnet restore
dotnet build
dotnet run --project P61_DynamicBasics
```
Targets `.NET 10.0` with `<LangVersion>4</LangVersion>` to enforce C# 4.0 syntax.
