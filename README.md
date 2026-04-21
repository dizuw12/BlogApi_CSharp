# Blog API – ASP.NET Core Web API

A backend REST API built with ASP.NET Core and Entity Framework Core, designed to simulate a real-world blog system.  
The project focuses on clean architecture principles, data management, and scalable API design.

---

## Project Overview

This application provides a fully functional backend for a blog platform.  
It allows managing blog posts with full CRUD operations, including searching, sorting, and data validation.

The project demonstrates practical backend development skills using modern .NET technologies.

---

## Key Features

- Full CRUD operations for blog posts
- Input validation and error handling
- Search functionality by post title
- Sorting posts by creation date 
- DTO based data transfer between layers
- Database integration using Entity Framework Core
- Code first database approach with migrations

---

## Tech Stack

- ASP.NET Core Web API
- Entity Framework Core
- SQL Server (LocalDB)
- LINQ
- C#
- DTO Pattern

---

## Architecture

The project follows a simplified layered architecture:

- **Controllers** – handle HTTP requests and responses
- **Models** – define database entities
- **DTOs** – manage data transfer between API and client
- **DbContext** – handles database communication via EF Core

This separation improves code maintainability and scalability.

---

## API Capabilities

### Posts Management
- Create new blog posts
- Retrieve all posts 
- Update existing posts
- Delete posts

### Advanced Querying
- Search posts by title
- Sort posts by creation date
