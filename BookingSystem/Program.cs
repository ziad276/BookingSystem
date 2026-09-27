using BookingSystem.Application.Repository;
using BookingSystem.Application.ServiceContracts;
using BookingSystem.Application.Services;
using BookingSystem.Infrastructure.Data;
using BookingSystem.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// MVC
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Repositories
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IProviderRepository, ProviderRepository>();
builder.Services.AddScoped<IAppointmentRepository, AppointmentRepository>();

// Services 
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IProviderService, ProviderService>();
builder.Services.AddScoped<IAppointmentService, AppointmentService>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();