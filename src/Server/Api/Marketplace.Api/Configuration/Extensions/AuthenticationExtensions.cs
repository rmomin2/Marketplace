using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Identity.Web;

namespace Marketplace.Api.Configuration.Extensions;

public static class AuthenticationExtensions
{
    public static IHostApplicationBuilder AddDefaultAuthentication(this IHostApplicationBuilder builder)
    {
        var services = builder.Services;
        var configuration = builder.Configuration;

        var azureB2C = configuration.GetRequiredSection("B2C");

        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddMicrosoftIdentityWebApi(options =>
        {
            configuration.Bind("B2C", options);
            options.TokenValidationParameters.NameClaimType = "name";
        },

        options => configuration.Bind("B2C", options));

        return builder;
    }
}
 