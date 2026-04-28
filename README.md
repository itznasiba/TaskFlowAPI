# TaskFlow-API
# TaskFlow-API - Task Management System

This project is a modern RESTful API system designed for task management, built using **C#** and **ASP.NET Core**. The primary goal of the project is to demonstrate clean code principles and a scalable software architecture.

## 🚀 Tech Stack

* **Framework:** .NET 9 / ASP.NET Core
* **Database:** MSSQL Server (Entity Framework Core)
* **Architecture:** N-Tier Architecture (Core, Business, DataAccess, API)
* **Design Patterns:** Generic Repository Pattern, DTO Pattern
* **Tools:** AutoMapper, Swagger UI, LINQ

## ✨ Key Features

* **N-Tier Architecture:** The project is separated into logical layers to ensure maintainability and testability.
* **Generic Repository Pattern:** Database operations are centralized and abstracted for better code reusability.
* **DTO (Data Transfer Object):** Sensitive data is protected by using DTOs for API responses and requests.
* **Automated Mapping:** Utilizes AutoMapper for seamless object-to-object transformations.
* **API Documentation:** Fully documented API endpoints using Swagger UI for interactive testing.

## 📂 Project Structure

- **TaskFlow.Core:** Contains Entities, DTOs, and base interfaces.
- **TaskFlow.Business:** Handles business logic (Services) and mapping configurations.
- **TaskFlow.DataAccess:** Manages database context, repository implementations, and migrations.
- **TaskFlow.WebAPI:** Contains Controllers and manages the external communication layer.

## 🛠️ Installation & Setup

1. Clone the repository:
   ```bash
   git clone [https://github.com/your-username/TaskFlow-API.git](https://github.com/your-username/TaskFlow-API.git)
