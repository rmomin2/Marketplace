using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Identity.Web;

namespace Marketplace.Api.Configuration.Extensions;

public static class AuthenticationExtensions
{
    public static IHostApplicationBuilder AddDefaultAuthentication(this IHostApplicationBuilder builder)
    {
        var azureB2C = builder.Configuration.GetRequiredSection("B2C");

        builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.Authority = $"{azureB2C["Authority"]}";
                options.Audience = azureB2C["Audience"]; 
                options.TokenValidationParameters.NameClaimType = "name";
                options.TokenValidationParameters.ValidateIssuer = true;
            });

        builder.Services.AddAuthorization();
        
        return builder;
    }
}
 