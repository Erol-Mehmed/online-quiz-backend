# Online Quiz System

## Description
Online Quiz System is an ASP.NET Core MVC web application that allows users to browse and solve quizzes, while administrators can manage quizzes and categories.

## Features
- User registration and login
- Role-based authorization (Admin/User)
- Quiz browsing
- Quiz categories
- Admin dashboard
- Quiz and category management
- Quiz creation, editing, and deletion

## Technologies Used
- ASP.NET Core MVC
- Entity Framework Core
- SQL Server
- ASP.NET Core Identity
- Bootstrap
- Razor Views

## Setup Instructions
1. Clone repository:
   git clone <repo-url>

2. Configure database connection in .env

3. Apply migrations:
   dotnet ef database update

4. Run the application to seed initial data:
   dotnet run

5. Open in browser:
   http://localhost:xxxx
