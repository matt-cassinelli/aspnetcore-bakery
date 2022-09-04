using Bakery.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<ICategoryRepository, MockCategoryRepository>(); // Add repositories to DI container.
builder.Services.AddScoped<IProductRepository, MockProductRepository>(); // AddScoped creates a singleton per request.

builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UseStaticFiles();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.MapDefaultControllerRoute();

app.Run();