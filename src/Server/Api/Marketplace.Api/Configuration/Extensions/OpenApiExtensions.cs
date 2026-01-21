using Asp.Versioning;
using Microsoft.OpenApi;
using System;
using System.Reflection.Metadata;
using System.Threading;

namespace Marketplace.Api.Configuration.Extensions;

public static class OpenApiExtensions
{
    public static IHostApplicationBuilder AddDefaultOpenApi(this IHostApplicationBuilder builder)
    {
        var configuration = builder.Configuration;
        var openApiSection = configuration.GetSection("OpenApi");

        if (!openApiSection.Exists())
        {
            return builder;
        }
        
        var azureB2C = configuration.GetSection("B2C");

        if (!azureB2C.Exists())
        {
            // No auth needed
            return builder;
        }

        builder.Services.AddApiVersioning(options => {
            options.ApiVersionReader = new UrlSegmentApiVersionReader();
            options.DefaultApiVersion = new ApiVersion(1, 0);
            options.AssumeDefaultVersionWhenUnspecified = true;
        }).AddApiExplorer(options =>
        {
            options.GroupNameFormat = "'v'VVV";
            options.SubstituteApiVersionInUrl = true;
        });

        builder.Services.AddOpenApi(options =>
        {
            options.AddDocumentTransformer((document, context, cancellationToken) =>
            {
                document.Components ??= new OpenApiComponents();
                document.Components.SecuritySchemes ??= new Dictionary<string, IOpenApiSecurityScheme>();
                var authSection = openApiSection.GetSection("Auth");
                var endpointSection = openApiSection.GetRequiredSection("Endpoint");

                document.Components.SecuritySchemes.Add("oauth2", new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.OAuth2,
                    Flows = new OpenApiOAuthFlows
                    {
                        AuthorizationCode = new OpenApiOAuthFlow
                        {
                            AuthorizationUrl = new Uri(azureB2C.GetRequiredValue("Authority") + "/oauth2/v2.0/authorize"),
                            TokenUrl = new Uri(azureB2C.GetRequiredValue("Authority") + "/oauth2/v2.0/token"),
                            Scopes = new Dictionary<string, string>
                        {
                            {
                                azureB2C.GetRequiredValue("ApiScope"), "API Access Scope"
                            }
                        }
                        }
                    }
                });

                document.Security = [
                    new OpenApiSecurityRequirement
                    {
                        {
                            new OpenApiSecuritySchemeReference("oauth2"),
                            [azureB2C.GetRequiredValue("ApiScope"), "API Access Scope"]
                        }
                    }
                ];

                document.SetReferenceHostDocument();
                return Task.CompletedTask;
            });
        });

        return builder;
    }

    public static WebApplication UseDefaultOpenApi(this WebApplication app)
    {
        var configuration = app.Configuration;
        var openApiSection = configuration.GetSection("OpenApi");

        if (!openApiSection.Exists())
        {
            return app;
        }

        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
            app.UseSwaggerUI(options =>
            {
                var pathBase = configuration["PATH_BASE"] ?? string.Empty;
                var authSection = openApiSection.GetSection("Auth");
                var endpointSection = openApiSection.GetRequiredSection("Endpoint");

                foreach (var description in app.DescribeApiVersions())
                {
                    options.SwaggerEndpoint($"/openapi/{description.GroupName}.json", description.GroupName);
                }

                if (authSection.Exists())
                {
                    var b2c = configuration.GetRequiredSection("B2C");
                    var clientId = authSection.GetRequiredValue("ClientId");

                    options.OAuthClientId(clientId);
                    options.OAuthUsePkce();
                    options.OAuthScopeSeparator(" ");
                    //options.OAuthAppName("Marketplace API");
                    //options.OAuthScopes(apiScope);
                    //var apiScope = b2c["ApiScope"];
                }
            });
        }

        return app;
    }
}
