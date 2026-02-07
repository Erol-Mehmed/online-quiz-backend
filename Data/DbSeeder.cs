using Microsoft.AspNetCore.Identity;
using OnlineQuizSystem.Models;

namespace OnlineQuizSystem.Data;

public static class DbSeeder
{
  public static async Task SeedAsync(IServiceProvider serviceProvider)
  {
    using var scope = serviceProvider.CreateScope();
    var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    
    // Ensure DB Exist
    await context.Database.EnsureCreatedAsync();
    
    // Roles
    if (!await roleManager.RoleExistsAsync("Admin"))
    {
      await roleManager.CreateAsync(new IdentityRole("Admin"));
    }
    
    if (!await roleManager.RoleExistsAsync("User"))
    {
      await roleManager.CreateAsync(new IdentityRole("User"));
    }
    
    // Admin user
    var adminEmail = "admin@quiz.com";
    
    var admin = await userManager.FindByEmailAsync(adminEmail);
    if (admin == null)
    {
      admin = new ApplicationUser
      {
        UserName = adminEmail,
        Email = adminEmail,
        EmailConfirmed = true,
      };
      
      await userManager.CreateAsync(admin, "Admin123!");
      await userManager.AddToRoleAsync(admin, "Admin");
    }
    
    // Categories
    if (!context.Categories.Any())
    {
      context.Categories.AddRange(
        new Category {Name = "Movies"},
        new Category {Name = "Books"},
        new Category {Name = "Music"},
        new Category {Name = "Sports"},
        new Category {Name = "Programming"},
        new Category {Name = "General Knowledge"}
      );
      
      await context.SaveChangesAsync();
    }
  }
}
