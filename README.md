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

Project Structure
.
├─ frontend/    # Angular Frontend
└─ backend/     # .NET Web API

Database Setup (MySQL)

Configure the connection string in:

backend/AssetInventory.Api/appsettings.Development.json


Example:

{
  "ConnectionStrings": {
    "DefaultConnection": "server=localhost;port=3306;user=root;password=yourpassword;database=asset_inventory;"
  }
}


Apply Entity Framework Core migrations to create or update the database:

dotnet ef database update


If migrations do not exist yet, create one first:

dotnet ef migrations add InitialCreate

Running the Backend

From the backend directory, run:

dotnet run


The Backend API will be available at:

http://localhost:5143

Running the Frontend

Navigate to the frontend directory:

cd frontend/asset-inventory-web


Install frontend dependencies:

npm install


Configure the API URL in:

frontend/asset-inventory-web/src/environments/environment.ts


Example:

export const environment = {
  production: false,
  apiUrl: 'http://localhost:5143/api'
};


Start the Angular development server:

ng serve


The Frontend application will be available at:

http://localhost:4200
