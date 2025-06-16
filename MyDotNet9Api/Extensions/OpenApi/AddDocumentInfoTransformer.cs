using Microsoft.AspNetCore.OpenApi;
using Microsoft.OpenApi.Models;

namespace MyDotNet9Api.Extensions.OpenApi;

/// <summary>
/// An OpenAPI document transformer that sets basic information (version, title, description, license)
/// for the generated OpenAPI document. This is used to customize the Swagger/OpenAPI metadata
/// for the API documentation.
/// </summary>
public class AddDocumentInfoTransformer : IOpenApiDocumentTransformer
{
    /// <summary>
    /// Modifies the OpenAPI document's Info section with custom version, title, description, and license.
    /// </summary>
    /// <param name="document">The OpenAPI document to transform.</param>
    /// <param name="context">The context for the document transformation.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>A completed task.</returns>
    public Task TransformAsync(OpenApiDocument document, OpenApiDocumentTransformerContext context,
        CancellationToken cancellationToken)
    {
        document.Info.Version = "v1";
        document.Info.Title = "Weather Forecast API";
        document.Info.Description = "A simple example ASP.NET Core Web API";
        document.Info.License = new OpenApiLicense()
        {
            Name = "MIT",
            Url = new Uri("https://mydotneet9api.com/license")
        };

        return Task.CompletedTask;
    }
}
