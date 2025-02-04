# University Project

## Overview
This project is developed using **C# with ASP.NET 4.7**, **Entity Framework 6.5.1**, and **MSSQL**. The architectural design follows the **Clean Architecture (Onion Architecture)** principles.

## Architecture Overview
- **Presentation Layer**: Handles user interactions.
- **Business Logic Layer**: Manages all processing and logic.
- **Domain Layer**: Encompasses all business rules and entities.
- **DAL (Data Access Layer)**: Provides access to the database and configurations.

## Setup and Installation
1. **Clone the repository**:
    ```sh
    git clone [your-repo-url]
    ```
2. **Navigate to the project directory** and **restore NuGet Packages**:
    ```sh
    nuget restore
    ```
    Install all dependencies, especially for Entity Framework:
    ```sh
    Install-Package EntityFramework -Version 6.5.1
    ```
3. **Install SQL Server Express LocalDB** from the [official website](https://docs.microsoft.com/en-us/sql/database-engine/configure-windows/sql-server-express-localdb).
4. **Modify the connection string**:
    ```xml
    <connectionStrings>
        <add name="DefaultConnection" connectionString="Data Source=(localdb)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Base.mdf;Integrated Security=True;Connect Timeout=30"/>
    </connectionStrings>
    ```
5. **Build and run the project**:
    ```sh
    msbuild
    dotnet run
    ```
