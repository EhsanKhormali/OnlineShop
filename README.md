## OnlineShop

This project is an ASP.NET Core application that combines a Razor Pages web application with a Web API. It follows the principles of Onion Architecture and utilizes MediatR for implementing the CQRS (Command Query Responsibility Segregation) pattern.

### Features

* **ASP.NET Core Razor Pages:** Provides a server-side rendering framework for building dynamic user interfaces.
* **ASP.NET Core Web API:** Exposes functionality through a RESTful API for consumption by other applications.
* **Entity Framework Core Code First:** Enables data access using a code-centric approach with migrations for schema management.
* **Repository Pattern:** Implements a separation of concerns between data access logic and business logic.
* **MediatR:** Implements the CQRS pattern for handling commands and queries.
* **Swagger UI:** Integrates interactive API documentation for easy exploration and testing of API endpoints.
* **Microsoft SQL Server:** Utilizes Microsoft SQL Server as the underlying relational database.

### Technologies

* ASP.NET Core
* Entity Framework Core
* Dapper (Optional, for low-level data access)
* Swashbuckle.AspNetCore (for Swagger UI)
* MediatR
* Microsoft SQL Server Client libraries

### Getting Started

1. Clone this repository.
2. Restore NuGet packages: `dotnet restore`
3. Update connection string in `appsettings.json` with your SQL Server details.
4. Run database migrations: `dotnet ef migrations add <migration_name>` and `dotnet ef database update`
5. Start the application: `dotnet run`
* **Note:** You cant edit admin user credential in OnlineShopContext.cs file.
* 
### Project Structure

* **OnlineShop solution:** Contains the source code for the application. To apply Onion Architechture the project sepereted to thee layer. Core is the most inside layer, infrustructure is middle layer that contains buisness logic and the peresentation layer. each layer refrences only the inner layer. below is projects that we can see in each layer:
    * **Pages:** Code for the Razor Pages web application. It's part of peresentation layer project OnlineShop
    * **ApiControllers:** Code for the Web API controllers and models and part of peresentation layer project OnlineShop
    * **Data:** Data access layer including repositories and entities. Is's part of infrustructure layer
    * **Application:** Contains classes implementing features of models and organied based CQRS design patern
    * **Domain:** Inner most layer project and models all entities without any regrences to upper layers
    * **Program.cs:** Main application configuration file.
    * **appsettings.json:** Stores application configuration settings.

### Deployment

The application can be deployed to various environments like IIS, Azure App Service, or Docker containers. Refer to the respective documentation for deployment instructions.

### Additional Notes

* This project follows the principles of Onion Architecture, which promotes better maintainability, testability, and flexibility.
* Consider implementing dependency injection for loose coupling and testability.
* Explore unit testing and integration testing practices for ensuring code quality and reliability.
