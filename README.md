# StudentsAppProject

StudentsAppProject is a simple ASP.NET Core Web API designed to manage students in a database. The project uses Entity Framework Core for database operations and provides endpoints for CRUD operations on student data. 

## Features
- **GET**: Fetch a list of all students.
- **POST**: Add a new student.
- **PUT**: Update an existing student's information.
- **DELETE**: Remove a student from the database.
- Swagger UI for API documentation and testing.

## Technologies
- ASP.NET Core
- Entity Framework Core
- SQL Server
- Swagger

## Prerequisites
- .NET SDK 6.0 or later
- SQL Server
- Visual Studio or any other IDE for development
- Postman or Swagger for testing API endpoints

## How to Run
1. Clone the repository:
   ```bash
   git clone https://github.com/milospetkovic/StudentsAppProject.git
   cd StudentsAppProject
   ```

2. Update the connection string in appsettings.json:
    ```
    {
        "ConnectionStrings": {
            "DefaultConnection": "Your SQL Server connection string here"
        }
    }
    ```
3. Run the following commands:
    ```bash
    dotnet restore
    dotnet build
    dotnet run
    ```

4. Open your browser and navigate to:
    http://localhost:(your-port)/swagger/index.html to test the API.