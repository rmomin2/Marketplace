using Marketplace.Api.Configuration.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.AddApplicationServices();

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();

app.MapEndPoints();
app.UseDefaultOpenApi();

app.Run();
