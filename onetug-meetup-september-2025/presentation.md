---
marp: true
title: Avoiding null! in C#
paginate: true
theme: default
author: Al Rodriguez
footer: '@ProgrammerAL and programmerAL.com'
---

# Avoiding null! in C#

with AL Rodriguez

![bg right 80%](presentation-images/presentation_link_qrcode.png)

---

# Me (AL)

- @ProgrammerAL
- https://ProgrammerAL.com
- Principal Backend Developer at Olympus

---

# Why are we here?

- Talk about null handling in C#
- Enable Nullable Reference Types (NRT)

---

# Null

- Nothing, no value, a default
- Classes in C# are null by default
- Wrap `if()` checks around code to ensure not null

---
```csharp
private void Combine(string a, string b, string c)
{
  var aShort = a.Substring(0, 2);
  var bShort = b.Substring(0, 2);
  var cShort = c.Substring(0, 2);

  return $"{aShort} {bShort} -- {cShort}";
}
```
---
```csharp
private void Combine(string a, string b, string c)
{
  if(a != null && b != null && c != null)
  {
    var aShort = a.Substring(0, 2);
    var bShort = b.Substring(0, 2);
    var cShort = c.Substring(0, 2);

    return $"{aShort} {bShort} -- {cShort}";
  }

  return "";
}
```
---
```csharp
public void FormatStrings(string a, string b, string c)
{
  if(a != null && b != null && c != null)
  {
    return Combine(a, b, c);
  }

  return "";
}

private void Combine(string a, string b, string c)
{
  var aShort = a.Substring(0, 2);
  var bShort = b.Substring(0, 2);
  var cShort = c.Substring(0, 2);

  return $"{aShort} {bShort} -- {cShort}";
}
```
---
```csharp
public void FormatStrings(string a, string b, string c)
{
  if(a != null && b != null && c != null)
  {
    return Combine(a, b, c);
  }

  return "";
}

public void DefaultCombine(string a, string b)
{
    return Combine(a, b, "Combined");
}

private void Combine(string a, string b, string c)
{
  var aShort = a.Substring(0, 2);
  var bShort = b.Substring(0, 2);
  var cShort = c.Substring(0, 2);

  return $"{aShort} {bShort} -- {cShort}";
}
```
---
# Nullable Reference Types (NRTs)

- Introduced in .NET 5 (2019!)
- **Warning**: Early on, More thinking for developer (Shift Left)

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

# More on NRTs

- NO CHANGE IN FUNCTIONALITY
- Added syntax for developers

---

# Using NRTs

- Adds syntax for null mapping (`!` and `?`)
- Adds attributes for compiler hints

---

# Using `?` with NRTS

- `?` means a variable May Be Null
- Excluding `?` means it is assumed to be Not Null

* `string? a = null;`
* `string? b = "abc";`
* `string c = "abc";`
* `string d = null;//Compiler Warning`

---

# Using `!` with NRTs

- `!` tells compiler to ignore a definite/possible null
- Should be a last resort

* `string a = null;//Compiler Warning`
* `string b = null!;`

---

```csharp
public void FormatStrings(string? a, string? b, string? c)
{
  if(a != null && b != null && c != null)
  {
    return Combine(a, b, c);
  }

  return "";
}

public void DefaultCombine(string? a, string? b)
{
    return Combine(a, b, "Combined");
}

public void LyingDefaultCombine(string? a, string? b)
{
    return Combine(a!, b!, "Combined");
}

private void Combine(string a, string b, string c)
{
  var aShort = a.Substring(0, 2);
  var bShort = b.Substring(0, 2);
  var cShort = c.Substring(0, 2);

  return $"{aShort} {bShort} -- {cShort}";
}
```
---

# Demo Code

---

# Attributes

- 11 Attributes (by last count)
- Helpers to tell the compiler what to do in situations
- Full List: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/attributes/nullable-analysis

---

# More on Attributes

- Helpful when the code isn't clear

---

# \[NotNullWhen\]

```
public bool TryParseNumber(string text, [NotNullWhen(true)] int? number)
{
  ...
}
```

---

# Event more \[NotNullWhen\]

```
if(TryParseNumber("abc-123"), out int? myNumber)
{
  Console.WriteLine(myNumber);
}

public bool TryParseNumber(string text, [NotNullWhen(true)] int? number)
{
  ...
}
```

---

# Demo Code

---

# Check for Null at "Ingress of the App"

- Check all entities coming into your code
  - HTTP Requests
  - External Service Calls
  - Database Calls*
- Require data should be default
  - Not always possible, more thinking now (shift-left)

---

# In Closing - Embrace NRTs

- NRTs find bugs
- A lot of code hassle can be mitigated

---

# Shameless Self-Promotion - In Depth Videos

- YouTube Series of these concepts, more in-depth
  - https://programmeral.com/posts/20250603_OpinionatedAspNetVideos
  - https://www.youtube.com/playlist?list=PLywNgcEGt3ofUBJsuriVX9A-93JPDi48A

---

# Online Info

- @ProgrammerAL
- https://ProgrammerAL.com
