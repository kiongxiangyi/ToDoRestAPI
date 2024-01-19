# ASP.NET Core Minimal APIs with Swagger/OpenAPI Integration

This project is a simple ASP.NET Core application that showcases the use of minimal APIs. Minimal APIs provide a streamlined way to build lightweight and focused web APIs with less ceremony. Additionally, the project is configured to utilize Swagger/OpenAPI for API documentation and exploration.

## Getting Started

1. Clone the repository:

    ```bash
    git clone https://github.com/your-username/MinimalAPIWithSwagger.git
    cd MinimalAPIWithSwagger
    ```

2. Build and run the application:

    ```bash
    dotnet run
    ```

Visit `http://localhost:5000` in your browser to access the API.

## Overview

The application is built using the `WebApplication` class in ASP.NET Core, and it utilizes the builder pattern with `WebApplicationBuilder`. It includes Swagger/OpenAPI integration for documenting and exploring the API endpoints.

### Swagger/OpenAPI Configuration

Swagger and Swagger UI are enabled in the development environment. Swagger provides a way to describe and document RESTful APIs, while Swagger UI is a user interface for exploring and interacting with the API.

Learn more about configuring Swagger/OpenAPI at [https://aka.ms/aspnetcore/swashbuckle](https://aka.ms/aspnetcore/swashbuckle).

### HTTPS Redirection

In the production environment, the application automatically redirects HTTP requests to HTTPS. This is a security best practice.

## API Endpoints

### Get all ToDos

- **Endpoint**: `/todos`
- **Method**: GET
- **Description**: Retrieve a list of all ToDo items.

### Get ToDo by ID

- **Endpoint**: `/todos/{id}`
- **Method**: GET
- **Description**: Retrieve a ToDo item by its ID.

### Create a new ToDo

- **Endpoint**: `/todos`
- **Method**: POST
- **Description**: Add a new ToDo item to the list.

### Update ToDo by ID

- **Endpoint**: `/todos/{id}`
- **Method**: PUT
- **Description**: Update a ToDo item by its ID.

### Delete ToDo by ID

- **Endpoint**: `/todos/{id}`
- **Method**: DELETE
- **Description**: Delete a ToDo item by its ID.

## Contributing

Contributions are welcome! Follow these steps:

1. Fork the repository.
2. Create a new branch: `git checkout -b feature/my-feature`.
3. Commit your changes: `git commit -m 'Add new feature'`.
4. Push to the branch: `git push origin feature/my-feature`.
5. Submit a pull request.

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## Additional Information

### HTTPS Redirect

It is a security best practice to use HTTPS in production environments. This middleware redirects HTTP requests to HTTPS.

### ToDoItem Class

The `TodoItem` class represents the structure of a ToDo item with a `Content` property. The API endpoints use this class for creating and updating ToDo items.
