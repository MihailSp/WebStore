using Microsoft.AspNetCore.Builder;
using WebStore.Infrastructure.Conventions;
using WebStore.Services;
using WebStore.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;

services.AddControllersWithViews(opt =>
{
    opt.Conventions.Add(new TestConvention());
});

services.AddScoped<IEmployeesData, InMemoryEmployeesData>();
services.AddScoped<IProductData, InMemoryProductData>();

var app = builder.Build();

if (app.Environment.IsDevelopment()) 
{
    app.UseDeveloperExceptionPage();
}

app.UseStaticFiles();

app.UseRouting();

app.MapGet("/trow", () => 
{
    throw new ApplicationException("Пример ошибки в приложении");
});

app.MapGet("/greetings", () => app.Configuration["ServerGreetings"]);

app.MapDefaultControllerRoute();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{Id?}");

app.Run();