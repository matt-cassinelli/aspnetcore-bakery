using Bakery.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<ICategoryRepository, CategoryRepository>(); // Add stuff to DI container for use throughout the app.
builder.Services.AddScoped<IProductRepository, ProductRepository>();   // AddScoped creates a singleton per request.
builder.Services.AddScoped<IOrderRepository, OrderRepository>();

builder.Services.AddScoped<IBasket, Basket>(sp => Basket.GetBasket(sp));
builder.Services.AddSession();
builder.Services.AddHttpContextAccessor();

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<MyDbContext>(options =>
    {
        options.UseSqlServer(builder.Configuration["ConnectionStrings:BakeryDbContext"]);
    }
);

var app = builder.Build();

app.UseStaticFiles();

app.UseSession();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Home}/{action=Index}/{id?}"
//);

app.MapDefaultControllerRoute(); // Configure all routes like host.com/controller/action/params

app.Run();