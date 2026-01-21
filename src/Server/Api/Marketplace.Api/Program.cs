using Marketplace.Api.Configuration.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.AddApplicationServices();
//builder.Services.AddOpenApi();

var app = builder.Build();

app.MapEndPoints();
app.UseDefaultOpenApi();

app.Run();
