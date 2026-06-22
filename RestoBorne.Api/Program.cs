using RestoBorne.Application.Interfaces; 
using RestoBorne.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapGet("/api/products", async (IProductRepository repository) =>
{
    var products = await repository.GetAllAsync();
    return Results.Ok(products);
})
.WithName("GetAllProducts");

app.Run();