📝 TodoApp – Full Stack Task Manager

This is a full stack Task Management Application built with:

Backend: ASP.NET Core (.NET 7), Entity Framework Core, MSSQL

Frontend: Angular 16, TypeScript, SCSS

Database: Microsoft SQL Server (Docker container)

Deployment: Docker Compose (backend + frontend + database containers)

🚀 Features

Create tasks with title + description

View recent tasks in a clean UI

Modern Angular frontend with SCSS styling

REST API with Entity Framework Core (code-first approach)

Docker Compose setup for one-command start

📂 Project Structure
Technical Assessment/
 ├── Backend/
 │     └── TodoApp/       # .NET Web API backend
 │          ├── Controllers/
 │          ├── Data/
 │          ├── DTOs/
 │          ├── Models/
 │          ├── Services/
 │          └── TodoApp.csproj
 ├── Frontend/
 │     └── todo-app/      # Angular frontend
 │          ├── src/
 │          └── package.json
 └── docker-compose.yml   # Docker multi-container setup

🐳 Run with Docker (Recommended)

Make sure you have Docker Desktop installed and running.

1️⃣ Build and start all containers:
docker-compose up --build

2️⃣ Access services:

Frontend (Angular): http://localhost:4200

Backend API (.NET): http://localhost:7241/api/tasks

Database (MSSQL): localhost:1433, user=sa, password=Your_password123

🖥 Run Locally (without Docker)
🔹 Backend

Navigate to backend:

cd Backend/TodoApp/TodoApp
dotnet restore
dotnet ef database update   # apply migrations
dotnet run


Backend runs at: http://localhost:5000

🔹 Frontend

Navigate to frontend:

cd Frontend/todo-app
npm install
ng serve -o


Frontend runs at: http://localhost:4200

⚙️ Configuration

Connection Strings: defined in appsettings.json and overridden by Docker environment variables.

SQL Server Credentials:

User: sa

Password: Your_password123

🧪 Testing

Backend: you can run unit tests with:

dotnet test


Frontend: run Angular tests with:

ng test

📦 Deployment

This repo is designed to be run easily with Docker Compose.
You can also deploy each container separately (backend + frontend + db) to Azure, AWS, or any container host.

👨‍💻 Author

Dilshan Samarakoon – Full Stack Developer
