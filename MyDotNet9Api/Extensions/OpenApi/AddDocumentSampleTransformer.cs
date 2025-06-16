using Microsoft.AspNetCore.OpenApi;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;

namespace MyDotNet9Api.Extensions.OpenApi;

// This class implements IOpenApiDocumentTransformer to inject a sample response example
// for the GET /weatherforecast endpoint in the OpenAPI document. It creates an example
// object with sample weather data and assigns it to the 200 OK response's application/json
// content. This helps API consumers see a concrete example of the response schema in Swagger UI.
public class AddDocumentSampleTransformer : IOpenApiDocumentTransformer
{
    public Task TransformAsync(OpenApiDocument document, OpenApiDocumentTransformerContext context,
        CancellationToken cancellationToken)
    {
        var path = document.Paths["/weatherforecast"];
        var operation = path.Operations[OperationType.Get];

        var example = new OpenApiObject
        {
            ["date"] = new OpenApiDate(DateTime.Today),
            ["temperatureC"] = new OpenApiInteger(18),
            ["summary"] = new OpenApiString("Sunny"),
            ["temperatureF"] = new OpenApiInteger(64),
        };

        operation.Responses["200"].Content["application/json"].Example = example;

        return Task.CompletedTask;
    }
}
