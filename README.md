# BookingSystem

A full-stack appointment booking application built with **ASP.NET Core MVC**, **Entity Framework Core**, **SQL Server**, and **ASP.NET Core Identity**.

BookingSystem allows users to create accounts, browse service providers, become providers, create appointment slots, and book or cancel appointments.

The application is organized into separate **Presentation, Application, Core, and Infrastructure** projects, following **Clean Architecture principles** and separation of concerns.

---

## ✨ Features

### 👤 Authentication & Identity

* User registration and login
* Logout functionality
* ASP.NET Core Identity
* Secure password hashing and user management
* Role-based authorization
* Provider role management
* Protected provider and appointment operations

### 🧑‍💼 Provider Management

* Browse available service providers
* Authenticated users can become service providers
* Provider accounts are associated with their Identity user
* Providers can create appointment slots
* Providers can view their appointments

### 📅 Appointment Management

* Providers can create appointment slots
* Users can browse available appointment slots
* Users can book available appointments
* Users can cancel their bookings
* Appointment ownership is checked during operations
* Appointment status is tracked throughout the booking workflow

### 🔐 Authorization

The application uses **ASP.NET Core Identity**, claims, and role-based authorization to protect application functionality.

Examples of protected operations include:

* Becoming a provider
* Creating appointments
* Managing provider appointments
* Booking appointments
* Cancelling bookings

---

## 🏗️ Architecture

The solution is divided into four projects:

```text
BookingSystem
│
├── BookingSystem
│   └── Presentation / UI
│
├── BookingSystem.Application
│   ├── Services
│   ├── Service Contracts
│   └── Repository Abstractions
│
├── BookingSystem.Core
│   ├── Entities
│   ├── Enums
│   └── Identity Entities
│
└── BookingSystem.Infrastructure
    ├── Data
    └── Repositories
```

### Dependency Direction

The application separates presentation, application logic, domain concepts, and infrastructure concerns:

```text
                 ┌─────────────────────┐
                 │     Presentation    │
                 │   ASP.NET Core MVC   │
                 └──────────┬──────────┘
                            │
                            ▼
                 ┌─────────────────────┐
                 │     Application     │
                 │ Services & Contracts│
                 └──────────┬──────────┘
                            │
                            ▼
                 ┌─────────────────────┐
                 │        Core         │
                 │ Entities & Domain   │
                 └─────────────────────┘
                            ▲
                            │
                 ┌──────────┴──────────┐
                 │   Infrastructure    │
                 │ EF Core & Repos      │
                 └─────────────────────┘
```

The **Core** layer contains domain concepts, while **Application** contains application workflows and abstractions. **Infrastructure** provides implementations for persistence and other technical concerns, while the **UI** handles presentation and HTTP requests.

---

## 🛠️ Tech Stack

| Technology                | Purpose                            |
| ------------------------- | ---------------------------------- |
| **C#**                    | Primary programming language       |
| **.NET / ASP.NET Core**   | Web application framework          |
| **ASP.NET Core MVC**      | Presentation layer                 |
| **Entity Framework Core** | ORM and data access                |
| **SQL Server**            | Relational database                |
| **ASP.NET Core Identity** | Authentication and user management |
| **Razor Views**           | Server-rendered UI                 |
| **Bootstrap**             | UI styling                         |
| **Dependency Injection**  | Service and repository composition |
| **Git / GitHub**          | Version control                    |

---

## 📂 Project Structure

### `BookingSystem`

The presentation layer.

Responsible for:

* MVC Controllers
* Razor Views
* ViewModels
* Authentication UI
* HTTP request handling
* Authorization attributes
* Dependency injection configuration

Controllers handle HTTP requests and delegate application operations to application services.

---

### `BookingSystem.Application`

Contains application-level logic and abstractions.

```text
Application
├── Repository
├── ServiceContracts
└── Services
```

Responsibilities include:

* Application services
* Business workflows
* Repository abstractions
* Booking logic
* Provider management
* Appointment management

Examples of application operations include:

```text
BecomeProvider
CreateAppointment
BrowseAvailableSlots
BookAppointment
CancelAppointment
```

---

### `BookingSystem.Core`

Contains the core domain concepts of the application.

```text
Core
├── Entities
├── Enums
└── IdentityEntities
```

Examples include:

* `Provider`
* `Appointment`
* Appointment status definitions
* Application user/domain identity models

The Core layer is designed to remain independent of infrastructure and presentation concerns.

---

### `BookingSystem.Infrastructure`

Contains infrastructure implementations.

```text
Infrastructure
├── Data
└── Repositories
```

Responsibilities include:

* Entity Framework Core
* Database context
* Database configuration
* Repository implementations
* Data persistence

Repository abstractions defined by the Application layer are implemented here, keeping persistence details outside the application logic.

---

## 🔄 Booking Workflow

### Customer

```text
Register / Login
      │
      ▼
Browse Providers
      │
      ▼
Select Provider
      │
      ▼
View Available Appointment Slots
      │
      ▼
Book Appointment
      │
      ▼
Appointment → Confirmed
```

### Provider

```text
Register / Login
      │
      ▼
Become Provider
      │
      ▼
Provider Account Created
      │
      ▼
Provider Role Assigned
      │
      ▼
Create Appointment Slots
      │
      ▼
Manage Appointments
```

---

## 🗄️ Data Model

The main domain relationships revolve around users, providers, and appointments.

```text
ApplicationUser
      │
      │ 1
      │
      │ 0..1
      ▼
   Provider
      │
      │ 1
      │
      │ *
      ▼
 Appointment
```

An `ApplicationUser` can become a `Provider`, while a provider can create multiple appointment slots.

Appointments maintain their own booking status, allowing the system to distinguish between available and confirmed appointments.

---

## 🔒 Authentication & Authorization

Authentication is implemented using **ASP.NET Core Identity**.

Authorization is enforced using ASP.NET Core authorization mechanisms.

For example:

```csharp
[Authorize]
```

restricts operations to authenticated users, while provider-specific operations use role-based authorization.

The application retrieves the authenticated user's identity through claims when performing ownership-sensitive operations.

This ensures that operations such as booking and cancellation are associated with the currently authenticated user rather than relying on an arbitrary user ID supplied by the client.

---

## 💡 Design Patterns & Concepts

The project demonstrates practical backend development concepts including:

* Layered architecture
* Clean Architecture principles
* Separation of concerns
* Dependency Injection
* Repository Pattern
* Service Layer
* ASP.NET Core Identity
* Role-based authorization
* Claims-based user identification
* Entity Framework Core
* Asynchronous programming with `async` / `await`
* Domain entities
* Business-rule validation

The application applies these concepts to a complete booking workflow rather than a collection of isolated CRUD operations.

---

## 🚀 Getting Started

### Prerequisites

Make sure the following are installed:

* [.NET SDK](https://dotnet.microsoft.com/download)
* [SQL Server](https://www.microsoft.com/sql-server)
* [Git](https://git-scm.com/)

Visual Studio or JetBrains Rider is recommended for development.

### 1. Clone the repository

```bash
git clone https://github.com/ziad276/BookingSystem.git
cd BookingSystem
```

### 2. Configure the database

Update the application's connection string in the appropriate configuration file.

Example:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=YOUR_SERVER;Database=BookingSystem;Trusted_Connection=True;TrustServerCertificate=True;"
  }
}
```

> Never commit real passwords, credentials, or production connection strings to source control.

### 3. Apply EF Core migrations

Install the Entity Framework Core CLI if necessary:

```bash
dotnet tool install --global dotnet-ef
```

Then apply the database migrations:

```bash
dotnet ef database update
```

### 4. Run the application

```bash
dotnet run
```

Or open the solution in Visual Studio and run the `BookingSystem` project.

---





## 📄 License

This project is licensed under the **MIT License**. See [`LICENSE.txt`](LICENSE.txt) for details.
