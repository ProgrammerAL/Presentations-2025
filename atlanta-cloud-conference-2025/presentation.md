---
marp: true
title: The State of Serverless: Azure 2025 Edition
paginate: true
theme: default
author: Al Rodriguez
---

# The State of Serverless: Azure 2025 Edition

with AL Rodriguez

![bg right 80%](presentation-images/presentation_link_qrcode.png)

---

# Me (AL)

- @ProgrammerAL
- https://ProgrammerAL.com
- Principal Backend Developer at Olympus

![bg right 80%](presentation-images/presentation_link_qrcode.png)

---

# What is this session?

- Discuss Serverless
- Overview of Serverless in Azure
  - Pros and Cons
- Introduction and Overview to Serverless

---

# In the beginning...

* We had servers
* Then Virtual Machines
* Then Virtual Machines in co-located spaces
* Then the cloud was created
  * and things got weird

---

# What is Serverless?

- Care about the Servers, less
- High level abstraction over the platform
  - Devs ignore: OS/CPU/Memory/Disk Space/etc

---

# "Serverless" got out of hand

- Became a Buzzword
  - Serverless meant everything
- Popular with Microservices

---

# Let's Define Serverless

- Scales to 0
- Pay for usage

---

# Pros of Serverless

* Only pay for what you use
* Simplified/Targeted development model

---

# Cons of Serverless

* Cold Boot
* Tightly coupled to the platform
* Can be more expensive than an always running service

---

# Serverless Types

- Compute
- Storage
- Database

---

# Serverless Compute

- Application Code
- Generally Functions
  - REST endpoints
  - Event driven
- Written for a custom platform

---

# Serverless Compute in Azure

- Azure Functions
- Azure Container Apps

---

# Azure Functions

- Different Process Models
  - In-Process vs Isolated
- Supports different programming languages
- Deployed from:
  - Single code file, zip file, container image

---

# Azure Container Apps

- Abstraction over Kubernetes

---

# Non-Serverless Compute

- Kubernetes (AKS) and Container Instances (ACI)
  - Someone is managing Pods
  - Pods are servers!
- Azure App Service
  - PaaS, pay for hours it's on
  - Abstraction over a VM

---

# Outside of Azure

- Javascript functions (Cloudflare, Vercel, everywhere else)
- WebAssembly (Cloudflare, Fermyon)

---

# Serverless Storage

- Storage Accounts
  - Blobs
  - Queue
  - Tables

---

# Serverless Database

- Azure Table Storage
- CosmosDB
- Azure Managed SQL

---

# Azure Table Storage

- Document database
- Part of Azure Storage
- Fun Fact: HaveIBeenPwned.com used this has DB until very recently

---

# CosmosDB

- Document Database
- Heavily pushed by Microsoft

---

# Azure Managed SQL

- Has a Serverless mode
- 

---

# Review


---

# Online Info

- @ProgrammerAL
- https://ProgrammerAL.com

![bg right 80%](presentation-images/presentation_link_qrcode.png)
