# Driver API

This is a driver ASP.NET API project that demonstrates a simple RESTful API.

## Getting Started

### Prerequisites

Before you begin, ensure you have the following installed:

- [.NET SDK](https://dotnet.microsoft.com/download)

## Installation

1. Download or clone the repository:

   ```bash
   git clone https://github.com/AmrGablla/driver-api.git
   ```

2. Navigate to the project directory:

   ```bash
   cd driver-api
   ```

3. Run the application:

   ```bash
   dotnet run
   ```

   The API will be accessible at `http://localhost:5116` and Swagger UI at `http://localhost:5116/swagger/index.html`.

## Why This Architecture

I selected this architecture to align with the company's vision of advancing towards a microservices-oriented approach, aiming to realize the following benefits:

- **Scalability**: The chosen architecture allows for easy scalability as the project grows. It provides a solid foundation to handle increased traffic and data.

- **Maintainability**: The separation of concerns and the modular structure of this architecture make the codebase more maintainable. It's easier to update, add features, and fix bugs without affecting other parts of the application.

- **Documentation**: The inclusion of Swagger UI provides interactive and user-friendly API documentation. This makes it easier for developers to understand and test the API endpoints.