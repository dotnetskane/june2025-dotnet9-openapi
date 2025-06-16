using Microsoft.AspNetCore.OpenApi;
using Microsoft.OpenApi.Models;

namespace MyDotNet9Api.Extensions.OpenApi;

public class AddDocumentSecuritySchemasTransformer : IOpenApiDocumentTransformer
{
    // This method adds a JWT Bearer security scheme to the OpenAPI document.
    // It ensures the document's Components and SecurityRequirements are initialized.
    // The method creates a bearer security scheme, adds it to the document's security schemes,
    // and then adds a security requirement referencing this scheme to require JWT authentication
    // for all API endpoints by default.
    public Task TransformAsync(OpenApiDocument document, OpenApiDocumentTransformerContext context,
        CancellationToken cancellationToken)
    {
        var bearerScheme = new OpenApiSecurityScheme
        {
            Type = SecuritySchemeType.Http,
            Scheme = "bearer",
            BearerFormat = "JWT",
            In = ParameterLocation.Header,
            Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "bearer" }
        };

        document.Components ??= new OpenApiComponents();
        document.Components.SecuritySchemes["bearer"] = bearerScheme;

        document.SecurityRequirements ??= new List<OpenApiSecurityRequirement>();
        document.SecurityRequirements.Add(new OpenApiSecurityRequirement
        {
            [bearerScheme] = [],
        });

        return Task.CompletedTask;
    }
}
