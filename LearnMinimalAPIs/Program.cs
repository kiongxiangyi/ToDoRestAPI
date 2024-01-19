// WebApplication is a class in ASP.NET Core used to configure and bootstrap a web application.
// CreateBuilder(args) is a static method that initializes a new instance of the WebApplicationBuilder class, which is a builder pattern used for setting up the web application.
using System.Reflection.Metadata.Ecma335;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// These lines configure the application to use Swagger/OpenAPI for documenting and exploring the API endpoints.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Build() is a method of the WebApplicationBuilder class, and it creates a new instance of WebApplication based on the configuration set up in the builder.
var app = builder.Build();

// Configure the HTTP request pipeline.
// In the development environment, Swagger and Swagger UI are enabled. Swagger provides a way to describe and document RESTful APIs, and Swagger UI is a user interface for exploring and interacting with the API.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//This middleware redirects HTTP requests to HTTPS. It is a security best practice to use HTTPS in production environments.
app.UseHttpsRedirection();

// Dictionary to store todo items with integer keys (Ids) and string values (Content).
var todoData = new Dictionary<int, string>();

app.MapGet("/todos", () =>
{
    return todoData;
})
.WithName("GetToDo")
.WithOpenApi(operation => new(operation)
{
    Summary = "Get all ToDos",
    Description = "Retrieve a list of all ToDo items."
});

app.MapGet("/todos/{id}", (int id) =>
{
    if (!todoData.TryGetValue(id, out var todo))
    {
        return Results.NotFound("Not Found");
    };
    return Results.Ok(todo);
})

.WithName("GetToDoByID")
.WithOpenApi(operation => new(operation)
{
    Summary = "Get ToDo by ID",
    Description = "Retrieve a ToDo item by its ID."
});


app.MapPost("/todos", (string content) =>
{
    // Find the maximum key in the dictionary
    int nextId = todoData.Keys.Count > 0 ? todoData.Keys.Max() + 1 : 1;

    //method Add: Adds the specified key and value to the dictionary.
    todoData.Add(nextId, content);
    return todoData;
})
.WithName("CreateNewToDO")
.WithOpenApi(operation => new(operation)
{
    Summary = "Create a new ToDo",
    Description = "Add a new ToDo item to the list."
});

app.MapPut("/todos/{id}", (int id, string content) =>
{
    //method TryGetValue: Gets the value associated with the specified key.
    if (!todoData.TryGetValue(id, out _)) //ignore output
    {
        return Results.NotFound("Not Found");
    };

    todoData[id] = content;

    return Results.Ok(todoData);

})
.WithName("UpdateToDo")
.WithOpenApi(operation => new(operation)
{
    Summary = "Update ToDo by ID",
    Description = "Update a ToDo item by its ID."
});

app.MapDelete("/todos/{id}", (int id) =>
{
    if (!todoData.TryGetValue(id, out _))
    {
        return Results.NotFound("Not Found");
    };
    todoData.Remove(id);
    return Results.Ok(todoData);
})
.WithName("DeleteToDo")
.WithOpenApi(operation => new(operation)
{
    Summary = "Delete ToDo by ID",
    Description = "Delete a ToDo item by its ID."
});

//Run() starts the web application and begins listening for incoming HTTP requests.
app.Run();


class TodoItem
{
    public required string Content { get; set; }
}