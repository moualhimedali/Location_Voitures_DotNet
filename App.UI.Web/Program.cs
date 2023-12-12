using App.ApplicationCore.Interfaces;
using App.ApplicationCore.Services;
using App.Infrastructure;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<DbContext, Context>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IServiceReservation, ServiceReservation>();
builder.Services.AddScoped<IServiceClient, ServiceClient>();
builder.Services.AddScoped<IServiceContrat, ServiceContrat>();
builder.Services.AddScoped<IServiceVoiture, ServiceVoiture>();
builder.Services.AddSingleton<Type>(t => typeof(GenericRepository<>));
builder.Services.AddTransient(typeof(IService<>), typeof(Service<>));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Client}/{action=LoginIn}/{id?}");

app.Run();
