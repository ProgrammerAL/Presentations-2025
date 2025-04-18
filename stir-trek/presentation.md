---
marp: true
title: Intro to OpenTelemetry for Developers
paginate: true
theme: gaia
author: Al Rodriguez
footer: 'ProgrammerAL and ProgrammerAL.com'
---

# Intro to OpenTelemetry for Developers

with AL Rodriguez

![bg right 80%](presentation-images/presentation_link_qrcode.png)

---

# Me (AL)

- @ProgrammerAL
- ProgrammerAL.com
- Principal Backend Developer at Olympus

![bg right 80%](presentation-images/presentation_link_qrcode.png)

---

# What is Observability?

"Observability is about getting the right information at the right time into the hands of the people who have the ability and responsibility to do the right thing. Helping them make better `technical and business decisions` driven by real data, not guesses, or hunches, or shots in the dark. Time is the most precious resource you have — your own time, your engineering team's time, your company's time." - Charity Majors (@mipsytipsy) CTO of Honeycomb

---

# Why Observability?

- Developers need runtime data to diagnose bugs
- I.T. Operations needs to know metrics like Requests Per Second, CPU and Memory usage
- P.M.s want to know usage statistics
  - Ex: How often a shopping cart is abandoned?

---

# 1957
- Fortran programming language created
- Plain text log messages go to console/text files

---

# 2025+
- More programming languages exist
- Plain text log messages to console/files/3rd party company solution
- Logs have higher verbosity, more data per line
  - Timestamp, log level, JSON output, Thread Id, Request Id, etc

![](presentation-images/log-message.png)

---

# Limitations of Plain Text Logs

- Data in files is hard, and expensive, to sift through
- Hard to combine logs for a distributed application
- 3rd Pary Vendors make this easier
  - Big dependency on the vendor
  - Devs must to learn that vendor's tools
- Example Scenario:
  - UI calls `Service A` which calls `Service B` which calls `Service C`
	- An exception occurs in `Service B` because of response from `Service C`

---

# Azure Application Insights SDK

- Upload Logs
- Upload Metrics
  - Usage patterns, trends, requests per second, etc
- Track Transactions
  - HTTP Requests
  - Custom Events (wrap methods, external dependency calls, etc)

---

# OpenTelemetry (OTel)

"OpenTelemetry is a collection of APIs, SDKs, and tools. Use it to instrument, generate, collect, and export telemetry data (metrics, logs, and traces) to help you analyze your software’s performance and behavior." - https://OpenTelemetry.io

---

# OpenTelemetry (OTel)

- Open standard for collecting telemetry data about distributed services
- Open Source, Vendor Neutral, Language Agnostic
- APIs and SDKs
- https://OpenTelemetry.io

---

# OTel is NOT Logging

- Structured data

---

# What kind of does OTel care about?

- Traces
  - Full lifetime of requests in the system
- Metrics
  - Numbers
    - Performance counters/requests per second/etc

---

# OTel Metrics

- Counters
- CPU/Memory usage on the box
- Requests per second

---

# OTel Traces

- Info for a request
- Full lifetime of the request

---

# OTel Trace

![](presentation-images/trace.png)

---

# Trace Spans

- Traces made up of child Spans
- Spans have child attributes
  - Key/Value pairs of custom data

---

# Trace Example

- Trace is created when a request comes into the system
- OTel SDK creates a span when making HTTP call out to 3rd party service
	- OTel SDK adds span atributes like Endpoint, Status Code, etc
- OTel SDK creates a span when calling a database
	- Custom code adds span attributes for the database call like query, runtime, cost
- Custom Code creates custom Span to track important work
  - Adds spans to track user id for a delete operation

---

# OTel SDK - Environment Variables

- Control SDK variables with Environment Variables
- `OTEL_EXPORTER_OTLP_ENDPOINT`
- `OTEL_EXPORTER_OTLP_HEADERS`
- `OTEL_SERVICE_NAME`

---

# Demo Time

---

# OTel Logs

- For Backwards Compatibility
- Each message added as a Span

---

# OTel Collector Agent

- Separate process to push 
- Reccomendation: Push OTel to locally run Collector Agent
  - Agent can batch, do retries, etc

![bg right 90%](presentation-images/otel-agent-sdk.png)

---

# OTel for UI

- Currently Experimental
- Requires more thinking when to start a new Trace
  - For specific operations?
  - When page loads?

---

![bg 90%](presentation-images/presentation_link_qrcode.png)

