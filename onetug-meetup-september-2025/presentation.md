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

# Nullable Reference Types (NRTs)

- Introduced in .NET 5 (2019!)
- Compiler Warning when compiler thinks something __*can be*__ null
- Early on, More thinking for developer (Shift Left)

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

# Using NRTs

- Adds syntax for null mapping (`!` and `?`)
- Adds attributes for compiler hints

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
