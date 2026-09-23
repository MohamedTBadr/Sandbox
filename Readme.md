# Sandbox

A personal **.NET Framework 4.8 sandbox** for experimenting with backend development, architecture, design patterns, and production-oriented engineering concepts.

This repository contains small, focused examples used to understand how things work, test ideas, reproduce issues, and document patterns before applying them to larger projects.

## Tech Stack

* C#
* .NET Framework 4.8
* ASP.NET Web API
* ASP.NET MVC / Web Forms
* Entity Framework / ADO.NET
* SQL Server
* Autofac
* Serilog
* OpenTelemetry
* Grafana / Prometheus / Loki
* Git / NuGet

## Topics

### C# & .NET

* C# fundamentals and advanced features
* LINQ and Collections
* Delegates and Events
* `async` / `await`
* Tasks and concurrency
* Multithreading
* Exception handling
* Reflection
* Attributes

### ASP.NET

* ASP.NET Web API
* MVC
* Web Forms
* Routing
* HTTP pipeline
* `DelegatingHandler`
* Authentication
* Authorization
* Filters
* Global exception handling
* DTOs and model binding

### Data Access

* Entity Framework 6
* ADO.NET
* Code First
* Migrations
* Relationships
* Transactions
* Query optimization
* `IEnumerable` vs `IQueryable`
* Optimistic concurrency
* SQL Server `rowversion`
* ETags / conditional requests

### Dependency Injection & Architecture

* Dependency Injection
* Constructor Injection
* Dependency Inversion
* Autofac
* Composition Root
* Dependency registration
* Dependency lifetimes
* Service registration
* Event consumer registration

### Events & DDD

* .NET Events
* Event publishers and consumers
* Custom `EventArgs`
* In-process events
* Domain Events
* Integration Events
* Domain-Driven Design (DDD)
* Entities
* Value Objects
* Aggregates
* Aggregate Roots
* Domain Services
* Repositories
* Domain invariants
* Bounded Contexts

### Logging & Observability

* Serilog
* Structured logging
* JSON logging
* Log levels
* Exception logging
* Correlation IDs
* Request/response logging
* OpenTelemetry
* Logs, Metrics, and Traces
* Grafana
* Prometheus
* Loki
* OTLP

### Testing

* Unit testing
* Mocking
* Testable architecture
* Service testing
* Domain logic testing
* Event consumer testing
* Exception testing

### Design Patterns

* Repository
* Factory
* Strategy
* Observer
* Adapter
* Decorator
* Singleton
* Dependency Injection

### Authentication & Security

* OAuth
* Bearer authentication
* JWT
* Claims
* Roles
* Policies
* Token expiration
* Token invalidation
* Authorization handlers

### Tooling & Infrastructure

* NuGet
* Git
* Build and packaging
* Deployment experiments
* Native interop
* P/Invoke
* COM interop

## Repository Structure

Projects and folders are organized around individual experiments rather than a single production application.

```text
Sandbox/
│
├── ConsoleSamples/
├── WebApiExamples/
├── DataSamples/
├── EventsExamples/
├── DDDExamples/
├── DependencyInjectionExamples/
├── LoggingExamples/
├── TestingExamples/
└── ...
```

Each experiment should remain small and focused on a specific concept.

## Learning Approach

For each experiment, the goal is to understand:

* **What** the technology or pattern does.
* **Why** it exists.
* **How** it works.
* **When** to use it.
* **When not** to use it.
* Its trade-offs and limitations.
* How it behaves under failure.
* How it affects maintainability and testing.
* How the concept scales into larger backend systems.

The sandbox is intentionally focused on understanding **engineering decisions**, not simply collecting code examples.

## Environment

* Visual Studio Community 2026
* .NET Framework 4.8
* Windows
* SQL Server

## Getting Started

1. Clone the repository.
2. Open the solution in Visual Studio.
3. Restore NuGet packages.
4. Build the solution.
5. Select the desired project as the startup project.
6. Run with `F5` or `Ctrl + F5`.

For experiments requiring external services or configuration, check the README/configuration notes inside the relevant project.

## Repository Philosophy

This is a **learning sandbox**, not a production application.

Experiments may intentionally contain simplified implementations, alternative approaches, or incomplete examples in order to isolate a specific concept.

When an experiment becomes obsolete, it can be moved to:

```text
archive/
```

Keep examples small, understandable, and reproducible.

## License

This repository is primarily for personal learning and experimentation.

If the repository is shared publicly, see the `LICENSE` file for usage terms.
