using BookingSystem.Application.ServiceContracts;
using BookingSystem.Application.Services;

var builder = WebApplication.CreateBuilder(args);

// MVC
builder.Services.AddControllersWithViews();

// DbContext (Infrastructure) — uncomment once built
// builder.Services.AddDbContext<AppDbContext>(options =>
//     options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Repositories (Infrastructure implementations) — uncomment once built
// builder.Services.AddScoped<IUserRepository, UserRepository>();
// builder.Services.AddScoped<IProviderRepository, ProviderRepository>();
// builder.Services.AddScoped<IAppointmentRepository, AppointmentRepository>();

// Services (Application layer — already built)
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