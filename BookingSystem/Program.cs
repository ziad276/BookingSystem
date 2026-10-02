using BookingSystem.Application.Repository;
using BookingSystem.Application.ServiceContracts;
using BookingSystem.Application.Services;
using BookingSystem.Core.Entities;
using BookingSystem.Core.Enums;
using BookingSystem.Core.IdentityEntities;
using BookingSystem.Infrastructure.Data;
using BookingSystem.Infrastructure.Data.SeedData;
using BookingSystem.Infrastructure.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

// MVC
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Repositories
builder.Services.AddScoped<IProviderRepository, ProviderRepository>();
builder.Services.AddScoped<IAppointmentRepository, AppointmentRepository>();

// Services 
builder.Services.AddScoped<IProviderService, ProviderService>();
builder.Services.AddScoped<IAppointmentService, AppointmentService>();

builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();



var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}


// Ensure the database is created
using (var scope = app.Services.CreateScope())
{
    Console.WriteLine("Seeding block started");
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
    var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    string[] roles = { "Provider" };


    foreach (var role in roles)
    {
        if (!await roleManager.RoleExistsAsync(role))
        {
            await roleManager.CreateAsync(new IdentityRole(role));
        }
    }


    if (!userManager.Users.Any())
    {
        var infrastructurePath = Path.GetDirectoryName(
            typeof(ApplicationDbContext).Assembly.Location
        )!;

        var path = Path.Combine(
            infrastructurePath,
            "Data",
            "SeedData",
            "seed-data.json"
        ); Console.WriteLine($"Looking for file at: {Path.GetFullPath(path)}");
        Console.WriteLine($"File exists: {File.Exists(path)}");
        var json = await File.ReadAllTextAsync(path);
        var seedData = JsonSerializer.Deserialize<SeedDataModel>(json);

        var createdProviders = new List<Provider>();

        foreach (var p in seedData.Providers)
        {
            var user = new ApplicationUser { Name = p.Name, Email = p.Email, UserName = p.Email };
            await userManager.CreateAsync(user, p.Password);
            await userManager.AddToRoleAsync(user, "Provider");

            var provider = new Provider { UserId = user.Id };
            context.Providers.Add(provider);
            await context.SaveChangesAsync(); // save now so provider.Id is generated

            createdProviders.Add(provider);
        }

        foreach (var c in seedData.Clients)
        {
            var user = new ApplicationUser { Name = c.Name, Email = c.Email, UserName = c.Email };
            await userManager.CreateAsync(user, c.Password);
            // no role assignment — being a client is just the default, unmarked state
        }

        // Assign all slots to the first seeded provider (adjust if you want multiple)
        var firstProvider = createdProviders.First();

        foreach (var s in seedData.Slots)
        {
            var provider = createdProviders[s.ProviderIndex];

            context.Appointments.Add(new Appointment
            {
                ProviderId = provider.Id,
                StartTime = DateTime.Today.AddDays(s.DaysFromNow).AddHours(s.StartHour),
                EndTime = DateTime.Today.AddDays(s.DaysFromNow).AddHours(s.EndHour),
                Status = s.IsBooked ? Status.Confirmed : Status.Available
            });
        }

        await context.SaveChangesAsync();
    }
}


app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();