# Fullstack Application (Angular + .NET Web API)

This repository contains a fullstack application consisting of a Frontend built with Angular and a Backend built with ASP.NET Core Web API. The Backend uses Entity Framework Core with MySQL and migrations for database management.

---

## Prerequisites

Before running the project, make sure the following tools are installed:

- Node.js (LTS recommended)
- Angular CLI
- .NET SDK 9
- MySQL Server
- Entity Framework Core CLI

Install EF Core CLI (if not already installed):

```bash
dotnet tool install --global dotnet-ef
```
Project Structure

```bash
.
├─ frontend/    # Angular Frontend
└─ backend/     # .NET Web API
```

Database Setup (MySQL)

Configure the connection string in:

```bash
backend/AssetInventory.Api/appsettings.Development.json
```

Example:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "server=localhost;port=3306;user=root;password=yourpassword;database=asset_inventory;"
  }
}
```


Apply Entity Framework Core migrations to create or update the database:

```bash
dotnet ef database update
```

If migrations do not exist yet, create one first:

```bash
dotnet ef migrations add InitialCreate
```

Running the Backend

From the backend directory, run:

```bash
dotnet run
```

The Backend API will be available at:

```arduino
http://localhost:5143
```

Running the Frontend

Navigate to the frontend directory:

```bash
cd frontend/asset-inventory-web
```

Install frontend dependencies:

```bash
npm install
```

Configure the API URL in:

```swift
frontend/asset-inventory-web/src/environments/environment.ts
```

Example:

```bash
export const environment = {
  production: false,
  apiUrl: 'http://localhost:5143/api'
};
```


Start the Angular development server:

```bash
ng serve
```

The Frontend application will be available at:

```arduino
http://localhost:4200
```