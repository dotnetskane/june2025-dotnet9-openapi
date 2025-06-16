# Project Overview
> [Microsoft announcement in GitHub Issue #54599](https://github.com/dotnet/aspnetcore/issues/54599)

This repository demonstrates the differences in how SwaggerUI and OpenAPI are handled between .NET 8 and .NET 9.

**OpenAPI** is a language-agnostic specification for describing HTTP APIs and has become a standard for documentation, testing, client code generation, AI integrations, and more.

**Swagger** was the original project that created the OpenAPI specification and has since become an umbrella term for tools like SwaggerUI, Swagger Editor, and Swagger Codegen – all built on top of OpenAPI.

**Swashbuckle** is a community-driven library that has long been the de facto way to integrate SwaggerUI into ASP.NET Core projects. Since .NET 5, Microsoft’s Web API templates have included Swashbuckle by default to simplify the setup of new API projects.

---

## ⚠️ Changes in .NET 9

Starting with .NET 9, Microsoft has removed SwaggerUI support from the default Web API template:

- **Swashbuckle is no longer included by default**  
  The project is no longer actively maintained and lacks a .NET 8 release.

- **SwaggerUI is no longer automatically generated**  
  If you want a UI, you’ll need to add it manually.

- **Alternatives**  
  This change opens up the opportunity for developers to choose other popular UI libraries such as `Scalar` or `NSwag`.

---

## 🧭 Microsoft's New Direction

Instead, Microsoft is focusing on:

- Making **OpenAPI documentation in JSON format** a first-class citizen in ASP.NET Core (via `Microsoft.AspNetCore.OpenApi`).
- Leaving the UI part to external tools like **NSwag**, **SwaggerUI**, **Scalar**, and others.
- Improving support in Visual Studio and VS Code for `.http` files and the **Endpoints Explorer** as alternatives to SwaggerUI for testing.

This aligns with a broader trend in .NET where Microsoft is moving away from “default magic” in favor of a more explicit and modular approach.  
This gives developers full flexibility in choosing their documentation workflow.

---

## 📦 The Projects in the Solution

- `MyDotNet8Api`: A .NET 8 Web API app with built-in SwaggerUI support (via Swashbuckle).
- `MyDotNet9Api`: A .NET 9 Web API app with OpenAPI support only – demonstrates how to manually add UI solutions like `Scalar` and `NSwag`, can be accessed using the endpoints `https://localhost:7133/swagger` and `https://localhost:7133/scalar`.

