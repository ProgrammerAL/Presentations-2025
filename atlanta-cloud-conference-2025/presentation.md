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

- <u>Introduction</u> and Overview to Serverless
  - Conversation
  - No Code
- Overview of Serverless in Azure
  - Pros and Cons
  - Specific Services
- Software Development Perspective*

---

# In the beginning...

* We had physical servers
* Then Virtual Machines
* Then Virtual Machines in co-located spaces
* Then the cloud was created
  * and things got weird

---

# After the cloud...

- More abstractions were added
- IaaS/PaaS/SaaS
- Serverless was born

---

# What is Serverless?

- Started with Compute
  - Grew to other types of services
- Care about the Servers, less
- High level abstraction over the platform
  - Devs ignore: OS/CPU/Memory/Disk Space/etc

---

# "Serverless" got out of hand

- Became a Buzzword
- Serverless meant everything
- Serverless meant nothing

---

# CNCF Definition of Serverless

* Abstracts servers away from the user
* Underlying software managed by service provider
  - Physical machine, VM, physical security, software updates
* Charged by usage
* Provider specific SDK/API/etc
* https://glossary.cncf.io/serverless

---

# Simpler Serverless Definition

- Scales 
  - Down 0, up to "infinity"
- Pay for usage
- Proprietary to the platform

---

# Pros of Serverless

- Only pay for what you use
- Simplified/Targeted development model

---

# Cons of Serverless

- Cold Boot
- Tightly coupled to the platform
- Can be more expensive than an always running service

---

# Serverless Types

- Compute
- Storage
- Database

---

# Serverless Compute

* Application Code
  - Written for a custom platform
* Run by a Trigger
  - REST endpoints
  - Event driven

---

# Serverless Compute in Azure

- Azure Functions
- Azure Container Apps
- Azure Logic Apps

---

# Azure Functions

* Triggers
  - HTTP, Queue, Database, Event Grid, IoT, and more!
* Supports different programming languages
* Deployed from:
  - Single code file, zip file, container image
* Pay per invocation*
  - First 1 million free

---

![bg 90%](presentation-images/azure-functions-code.png)

---

# Azure Container Apps

* Abstraction over Kubernetes
* Mainly HTTP Triggers
  - Has some other triggers
* Pay per invocation, plus CPU/Memory Usage
  - First 180,000 seconds free

---

# Azure Logic Apps

* No-Code Platform, build Workflows
  - UI Based
* Big Feature: Connectors
* Consumption Tier, pay per invocation 

---

![bg 60%](presentation-images/logic-apps-code.png)

---

# Non-Serverless Compute

* Kubernetes (AKS) and Container Instances (ACI)
  - You manage Pods and Kubernetes Version
* Azure App Service
  - PaaS, pay for hours it's on
  - Abstraction over a VM

---

# Outside of Azure

- Javascript functions (Cloudflare, Vercel, everywhere else)
- WebAssembly (Cloudflare, Fermyon)

---

# Serverless Storage

- Azure Storage Accounts
  - Blobs
  - Queue
- Azure Service bus

---

# Blobs

- REST API
- Scales "forever"
- Cost: storage usage and transactions

---

# Queue Storage

- It's a queue!
  - 1 reader
- Scales "forever"
- Cost: storage usage and transactions

---

# Service Bus

- Also a Queue!
  - Many readers
- Per for transaction

---

# Serverless Databases

- Azure Managed SQL
- CosmosDB
- Azure Table Storage

---

# Azure SQL Database

- MS SQL Server
  - Not proprietary*
- Has a Serverless mode
  - scales to 0
- Pay per usage while on, and storage usage

---

# CosmosDB

- Document Database
- Heavily pushed by Microsoft
- Has a Serverless mode
  - Flag set when creating
- Pay per query difficulty, and storage usage

---

# Azure Table Storage

- Document database
  - Part of Azure Storage
- Fun Fact: HaveIBeenPwned.com used this has DB until very recently
- Pay per transaction and storage usage

---

# Event Driven Architecture

- Thrives off serverless
- Triggered by services

![bg right 80%](presentation-images/event-driven.svg)

---

# Review

* Serverless Definition
  - Scales
  - Pay for usage
  - Proprietary
* Compute
  - Functions, Container Apps, Logic Apps
* Storage
  - Blobs, Queues, Service Bus
* Database
  - Managed SQL Server, Cosmos DB, Table Storage

---

# Online Info

- @ProgrammerAL
- https://ProgrammerAL.com

![bg right 80%](presentation-images/presentation_link_qrcode.png)
