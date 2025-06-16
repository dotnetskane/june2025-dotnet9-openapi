using Microsoft.AspNetCore.OpenApi;
using Microsoft.OpenApi.Models;

namespace MyDotNet9Api.Extensions.OpenApi;

// This class implements IOpenApiDocumentTransformer to modify the OpenAPI document during generation.
// Specifically, it sets the Servers property of the OpenApiDocument to include two server URLs:
// one for local development and one for production.
// This ensures that the generated Swagger/OpenAPI documentation lists both endpoints as available servers.
public class AddDocumentServersTransformer : IOpenApiDocumentTransformer
{
    public Task TransformAsync(OpenApiDocument document, OpenApiDocumentTransformerContext context,
        CancellationToken cancellationToken)
    {
        document.Servers = [
            new OpenApiServer { Url = "https://localhost:7133" },
            new OpenApiServer { Url = "https://my-weather-api9.com" }
        ];
        return Task.CompletedTask;
    }
}
