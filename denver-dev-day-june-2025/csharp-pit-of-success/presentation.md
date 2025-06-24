---
marp: true
title: Setting Up Your C# Pit of Success
paginate: true
theme: default
author: Al Rodriguez
footer: '@ProgrammerAL and programmerAL.com'
---

# Setting Up Your C# Pit of Success

with AL Rodriguez

![bg right 80%](presentation-images/presentation_link_qrcode.png)

---

![bg 80%](presentation-images/sponsors.svg)

---

# Me (AL)

- @ProgrammerAL
- https://ProgrammerAL.com
- Principal Backend Developer at Olympus

![bg right 80%](presentation-images/presentation_link_qrcode.png)

---

# Why are we here?

- Discuss a C# Pit of Success
  - Enforce code quality
- Present ***Recommendations***
  - Please limit your yelling
- All Free*

---

# Pit of Success

"The Pit of Success: in stark contrast to a summit, a peak, or a journey across a desert to find victory through many trials and surprises, we want our customers to simply fall into winning practices by using our platform and frameworks. To the extent that we make it easy to get into trouble we fail."
           
-Rico Mariani, MS Research MindSwap Oct 2003.


- https://blog.codinghorror.com/falling-into-the-pit-of-success/

---

# What does a "Pit of Success" get us?

- Guard Rails
- Uniformity
- Shift-Left
  - More work now, less work later

---

# This session is a set of Recommendations:

- Some build on each other
- Your call to use or not
- Don't yell at me

---

# Recommendation: 
## Treat Warnings as Errors

- "Strict Mode"
- Don't compile if warning found
  - Ex: Not using method return
- Single Line in `*.csproj` file
- Later recommendations built on this

---

# How to Enable Warnings as Error in CsProj

```xml
<PropertyGroup>
  <TreatWarningsAsErrors>true</TreatWarningsAsErrors>
<PropertyGroup>
```

---

# Recommendation:
## Embrace Nullable References Types (NRTs)

- Stop yelling at me!
  - They're good! I swear.
- Not as hard as Rust!
- A lot of code hassle can be mitigated

---

# What are NRTs?

- Nullable Reference Types
- Compiler check for null value at Compile Time
- Compiler Warning when compiler thinks something __*can be*__ null

```xml
<PropertyGroup>
  <Nullable>enable</Nullable>
<PropertyGroup>
```

---

# Sample NRT Usage

```csharp
public void SomeMethod()
{
  var userId = LoadUserId(_context);
  Console.WriteLine(userId);//Generates Compiler Warning
}

private string? LoadUserId(HttpContext? context)
{
  if(context is null)
  {
    return null;
  }

  return context.ParseUserId();
}
```
---

# Check for Null at "Ingress of the App"

- Check all entities coming into your code
  - HTTP Requests
  - External Service Calls
  - Database Calls*
- Require data should be default
  - Not always possible, more thinking now (shift-left)

--- 

# Nullable References Types Finds Bugs

- See Title

---

# Recommendation: 
## Static Code Analysis

- Checks for common code issues
  - Sometimes fixes
- Enforce styling rules

---

# External Tools You Can Install

- SonarSource / SonarQube / SonarCloud
- CodeMaid
- FxCop
- Rider / Resharper
- Visual Studio

---

# Roslyn Analyzers

- Scan code at compile time
  - Built-in ones
  - Add with NuGets
  - Build your own
- May include code fixes

---

# Built-In Roslyn Analyzers

```xml
<PropertyGroup>
  <EnableNETAnalyzers>true</EnableNETAnalyzers>
  <EnforceCodeStyleInBuild>true</EnforceCodeStyleInBuild>
  <IncludeOpenAPIAnalyzers>true</IncludeOpenAPIAnalyzers>
  <EnableRequestDelegateGenerator>true</EnableRequestDelegateGenerator>
  <EnableConfigurationBindingGenerator>true</EnableConfigurationBindingGenerator>
</PropertyGroup>
```

- Note: `Microsoft.CodeAnalysis.NetAnalyzers` Package or `<EnableNETAnalyzers>` replaced FxCop

---

# Add Analyzers with NuGet Packages

- `*.Analyzers` package
  - `XUnit.Analyzers`
  - `Roslynator.Analyzers`
  - `Microsoft.Azure.Functions.Worker.Sdk.Analyzers`
  - `SonarAnalyzer.CSharp`

---

# Recommendation: 
## Manage all Static Rules in One Place

- .editorconfig file

---

# `.editorconfig` File

- Extensible/ Open Standard / Configurable / etc
- Single file checked into source control
- Different languages have different levels of support for it
  - C# support is really good
- https://editorconfig.org

---

```
# C# files
[*.cs]

#### Core EditorConfig Options ####

# Indentation and spacing
indent_size = 4
indent_style = space
tab_width = 4

# New line preferences
end_of_line = crlf
insert_final_newline = true

# Parentheses preferences
dotnet_style_parentheses_in_arithmetic_binary_operators = always_for_clarity:error
dotnet_style_parentheses_in_other_operators = never_if_unnecessary:silent

# Built-In Error Codes
csharp_style_deconstructed_variable_declaration = true:suggestion
dotnet_style_coalesce_expression = true:suggestion

# Specific Error Codes
dotnet_diagnostic.S3267.severity = suggestion
dotnet_diagnostic.SA1403.severity=error
```
---

# It's okay to suppress rules in specific cases

- `GlobalSuppressions.cs` file
- Individual `SuppressMessage` attribute

---
# Recommendation: 
## Codify Code Patterns

- Don't rely on humans to always do things right
- PRs only go so far

---

# Custom Roslyn Analyzers

- Make your own
  - Specific to your projects
- Example:
  - All ASP.NET Controller Endpoints must include `[Authorize]` or `[AllowAnonymous]` attribute

---

# Source Generators

- Add new code at compile time
- Already used by the .NET Team heavily for AoT stuff

---

# Common Interface Example

```csharp
public interface IUserManager
{
  ValueTask UpdateNameAsync(string name);
}

public class UserManager : IUserManager
{
  public async ValueTask UpdateNameAsync(string name)
  {
    await Task.CompletedTask;
  }
}

//Register with IoC Container
builder.Services.AddScoped<IUserManager, UserManager>();
```
---
# Generated Interface Example

```csharp
[GenerateSimpleInterface]
public class UserManager : IUserManager
{
  public async ValueTask UpdateNameAsync(string name)
  {
    await Task.CompletedTask;
  }
}

//Register with IoC Container
builder.Services.AddScoped<IUserManager, UserManager>();

```
---

# Recommendation: 
## Secure your Software Supply Chain

- Update Dependencies
  - Update nugets each sprint

---

# Protect Against NuGet CVEs

```xml
<PropertyGroup>
  <NuGetAudit>true</NuGetAudit>
  <NuGetAuditMode>all</NuGetAuditMode>
  <NuGetAuditLevel>low</NuGetAuditLevel>
</PropertyGroup>
```

- Adds build warnings
  - https://learn.microsoft.com/en-us/nuget/concepts/auditing-packages

---

# Recommendation: 
## Use .NET Aspire

- The New Hotness
- Handy for local feedback
- Also tries to setup a Pit of Success for devs
  - Set config with service discovery instead of hard coding
  - Good defaults for Observability (OpenTelemetry!)

---

# Recommendation: 
## Continuous Testing

- Continuous Testing Tools
  - NCrunch
  - Resharper*/Rider*
  - Visual Studio*
  - `dotnet watch`

\* = certain licenses of that product

---

# Review

- Warnings as Errors
- Nullable Reference Types
- Static Code Analysis
- Codify Patterns
- Secure Supply Chain
- Continuous Testing

---

# Online Info

- @ProgrammerAL
- https://ProgrammerAL.com

![bg right 80%](presentation-images/presentation_link_qrcode.png)
