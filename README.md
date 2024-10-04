<h1>Vite + React App</h1>

<h2>Frontend:</h2> The Vite + React app handles the user interface, allowing users to interact with the file management system. React can call backend APIs to handle tasks like file upload, download, and metadata management.

<h2>Backend:</h2> ASP.NET Core Web API serves as the backend for handling requests from the frontend. You can use EF Core in the backend to interact with your database (for storing file information, user data, etc.).

<h2>Database:</h2> EF Core simplifies CRUD operations by mapping your C# classes to database tables. You can define models for files, users, or any other entities relevant to your project

<h2>Arhitecture:</h2>
<ul>
<li>Vite helps with rapid development of your React frontend.
<li>React manages the web app interface and communicates with the backend API.
<li>ASP.NET Core Web API handles the business logic, data storage, and file operations.
<li>EF Core manages interactions with your database, handling migrations and querying the data.
</ul>

<h1>Migrations</h1>
Here is a quick reference for common commands used in Entity Framework Core migrations:

### 1. Create a Migration

To create a new migration based on changes in your entity classes or `DbContext`, use:

```bash
dotnet ef migrations add MigrationName
```
###2. Apply the Migration to the Database
To apply all pending migrations and update your database schema, use:

```bash
dotnet ef database update
```
###3.Rollback to a Specific Migration
To rollback the database to a previous migration, specify the migration name:

```bash
dotnet ef database update PreviousMigrationName
```
Replace `PreviousMigrationName` with the name of the migration you want to revert to.
