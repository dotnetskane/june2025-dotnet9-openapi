using System.ComponentModel.DataAnnotations;

namespace MyDotNet8Api;

public record WeatherForecast
{
    /// <summary>
    /// The date of the weather forecast.
    /// </summary>
    /// <example>2025-05-10</example>
    public DateOnly Date { get; init; }

    /// <summary>
    /// The temperature in Celsius.
    /// </summary>
    /// <example>21</example>
    public int TemperatureC { get; init; }

    /// <summary>
    /// The temperature in Fahrenheit, calculated from Celsius.
    /// </summary>
    /// <example>69</example>
    public int TemperatureF => 32 + (int)(TemperatureC * 1.8);

    /// <summary>
    /// A brief summary or description of the weather.
    /// </summary>
    /// <example>Sunny</example>
    public string? Summary { get; init; }
}
