University Project: ASP.NET 4.8 Online Marketplace
This project is an online marketplace for electronics, developed as part of a university course. It demonstrates the use of various web development technologies and practices.

Technologies Used
ASP.NET 4.8: The main framework for building the web application.

Entity Framework: Used for object-relational mapping and data access.

MS SQL Server: The database system, with an MDF file included in the project for easy setup.

HTML, CSS: For structuring and styling the web pages.

JavaScript, jQuery: For client-side scripting and interactivity.

Architecture
This project uses a monolithic architecture with the following layers:

Application Layer: Manages application logic and user interactions.

Business Layer: Implements business logic.

Domain Layer: Manages domain entities and data access.

API Endpoints
The application is built around the following API endpoints:

User API

Guest: Basic access for viewing products.

Admin: Administrative functions for managing users and products.

User: Registered user functionalities like adding to cart, checking out.

Product API

CRUD operations (Create, Read, Update, Delete) for product management.

Setup Instructions
Clone the repository.

Open the solution file in Visual Studio.

Restore NuGet packages.

Ensure the MSSQL Server is running and the MDF file is attached.

Build and run the project.

Contributions
Feel free to fork this repository and make contributions via pull requests.
