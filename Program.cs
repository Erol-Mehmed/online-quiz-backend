using Microsoft.EntityFrameworkCore;
using OnlineQuizSystem.Data;
using OnlineQuizSystem.Models;
using Microsoft.AspNetCore.Identity;

DotNetEnv.Env.Load();

var builder = WebApplication.CreateBuilder(args);

// ENV vars
string dbHost = Environment.GetEnvironmentVariable("DB_HOST") ?? "";
string dbPort = Environment.GetEnvironmentVariable("DB_PORT") ?? "";
string dbName = Environment.GetEnvironmentVariable("DB_NAME") ?? "";
string dbUser = Environment.GetEnvironmentVariable("DB_USER") ?? "";
string dbPassword = Environment.GetEnvironmentVariable("DB_PASSWORD") ?? "";

string connectionString =
  $"Server={dbHost},{dbPort};Database={dbName};User Id={dbUser};Password={dbPassword};TrustServerCertificate=True;";

// Routing
builder.Services.AddRouting(options =>
{
  options.LowercaseUrls = true;
});

// EF Core
builder.Services.AddDbContext<ApplicationDbContext>(options =>
  options.UseSqlServer(connectionString)
);

// Identity
builder.Services
  .AddIdentity<ApplicationUser, IdentityRole>(options =>
  {
    options.SignIn.RequireConfirmedAccount = true;
  })
  .AddEntityFrameworkStores<ApplicationDbContext>()
  .AddDefaultTokenProviders();

// MVC + Razor Pages
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
  app.UseExceptionHandler("/Home/Error");
  app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

// MVC routes
app.MapControllerRoute(
  name: "default",
  pattern: "{controller=Quiz}/{action=Index}/{id?}");

app.MapRazorPages();

await DbSeeder.SeedAsync(app.Services);

app.Run();
