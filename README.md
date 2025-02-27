# University Project

## Overview
This project is developed using **C# with ASP.NET 4.8.1 using Razor on Front-End (Template)**, **Entity Framework 6.5.1**, and **MSSQL**. The architectural design follows the **Clean Architecture (Onion Architecture)** principles.

## Architecture Overview
- **Presentation Layer**: Handles user interactions.
- **Business Logic Layer**: Manages all processing and logic.
- **Domain Layer**: Encompasses all business rules and entities.
- **DAL (Data Access Layer)**: Provides access to the database and configurations.

## Setup Instructions

1. **Clone the repository.**
2. **Restore NuGet packages: update them if possible.**
3. **Install IIS server.**
4. **Install MSSQL Express (or full version) on your local machine.**
5. **Update the connection string to specify your server**:

   ```xml
   <connectionStrings>
       <add name="DefaultConnection" connectionString="Data Source=INC;Initial Catalog=Store;Integrated Security=True;Connection Timeout=30;" providerName="System.Data.SqlClient" />
       <add name="MasterConnectionString" connectionString="Data Source=INC;Initial Catalog=master;Integrated Security=True;Connection Timeout=30;" providerName="System.Data.SqlClient" />
   </connectionStrings>
   ```
