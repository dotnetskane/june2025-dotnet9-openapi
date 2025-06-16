using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using MyDotNet9Api.Extensions.OpenApi;
using Scalar.AspNetCore;
using System.Xml.Linq;

var builder = WebApplication.CreateBuilder(args);


// Registers and configures OpenAPI (Swagger) services for API documentation generation and customization
builder.Services.AddOpenApi(options =>
{
    options.AddDocumentTransformer<AddDocumentInfoTransformer>();
    options.AddDocumentTransformer<AddDocumentServersTransformer>();
    options.AddDocumentTransformer<AddDocumentSecuritySchemasTransformer>();
    options.AddDocumentTransformer<AddDocumentSampleTransformer>();
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUi(settings =>
    {
        settings.DocumentPath = "/openapi/v1.json";
    });
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast = Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = summaries[Random.Shared.Next(summaries.Length)]
        })
        .ToArray();
    return forecast;
}).WithName("GetWeatherForecast")
.WithSummary("Gets a 5-day weather forecast with random data.")
.WithDescription("Returns a 5-day weather forecast with random temperature and summary values.")
.WithTags("WeatherForecast")
.Produces<WeatherForecast>(200, contentType: "application/json")
.ProducesProblem(500, "application/json");

app.Run();

internal record WeatherForecast()
{
    [Description("Date of forecast")]
    [Required]
    public DateOnly Date { get; set; }

    [Description("Temperature in Celsius")]
    [Required]
    public int TemperatureC { get; set; }

    [Description("Short summary of weather")]
    public string? Summary { get; set; }

    [Description("Temperature in Farenheit, calculated from Celsius")]
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}