using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// AddEndpointsApiExplorer is required in .NET 8 to enable API endpoint discovery for minimal APIs and controllers.
// It generates metadata used by Swagger to document and test the API endpoints.  

builder.Services.AddEndpointsApiExplorer();

// AddSwaggerGen is used to register the Swagger generator service.
// This is required in order to generate the Swagger documentation for the API.
builder.Services.AddSwaggerGen(options =>
{
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    options.IncludeXmlComments(xmlPath, includeControllerXmlComments: true);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // UseSwagger is used to enable the Swagger middleware in the application.
    // This middleware serves the generated Swagger JSON document.
    app.UseSwagger();

    // UseSwaggerUI is used to enable the Swagger UI middleware in the application.
    // This middleware serves the interactive Swagger UI that allows users to explore and test the API endpoints.
    // The Swagger UI is a web-based interface that provides a user-friendly way to interact with the API.
    // It is typically used in development environments to test and document the API.
    // In production, you might want to disable this for security reasons.
    // You can also customize the Swagger UI by providing options such as the route prefix and document title.
    // When the application starts upp you can access the Swagger UI at /swagger/index.html
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
