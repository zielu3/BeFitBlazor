using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using BeFitBlazor.Data;

namespace BeFitBlazor;

public static class RoleInitializer
{
    public static async Task InitializeRolesAndUsersAsync(IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();
        var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
        var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
        var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        await db.Database.MigrateAsync();

        const string adminRole = "Admin";
        const string adminEmail = "admin@befit.com";
        const string adminPassword = "Admin123!";
        const string testUserEmail = "adam@wp.pl";
        const string testUserPassword = "Adam123!";

        if (!await roleManager.RoleExistsAsync(adminRole))
        {
            await roleManager.CreateAsync(new IdentityRole(adminRole));
        }

        // konto administratora
        var adminUser = await userManager.FindByEmailAsync(adminEmail);
        if (adminUser == null)
        {
            adminUser = new ApplicationUser
            {
                UserName = adminEmail,
                Email = adminEmail,
                EmailConfirmed = true
            };
            var createResult = await userManager.CreateAsync(adminUser, adminPassword);
            if (createResult.Succeeded)
            {
                await userManager.AddToRoleAsync(adminUser, adminRole);
            }
        }
        else if (!await userManager.IsInRoleAsync(adminUser, adminRole))
        {
            await userManager.AddToRoleAsync(adminUser, adminRole);
        }

        // konto uzytkownika
        var testUser = await userManager.FindByEmailAsync(testUserEmail);
        if (testUser == null)
        {
            testUser = new ApplicationUser
            {
                UserName = testUserEmail,
                Email = testUserEmail,
                EmailConfirmed = true
            };
            await userManager.CreateAsync(testUser, testUserPassword);
        }
    }
}
