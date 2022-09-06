using Bakery.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<ICategoryRepository, CategoryRepository>(); // Add repositories to DI container.
builder.Services.AddScoped<IProductRepository, ProductRepository>(); // AddScoped creates a singleton per request.

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<BakeryDbContext>(options =>
    {
        options.UseSqlServer(builder.Configuration["ConnectionStrings:BakeryDbContext"]);
    }
);

var app = builder.Build();

app.UseStaticFiles();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.MapDefaultControllerRoute();

app.Run();