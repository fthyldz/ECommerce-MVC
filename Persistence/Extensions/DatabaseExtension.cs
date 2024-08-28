using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Context;

namespace Persistence.Extensions;

public static class DatabaseExtension
{
    public static async Task InitialiseDatabaseAsync(this WebApplication app, bool isDevelopment)
    {
        using var scope = app.Services.CreateScope();

        var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

        //if (!isDevelopment)
        await context.Database.MigrateAsync();

        //if (isDevelopment)
        await SeedAsync(context);
    }

    private static async Task SeedAsync(ApplicationDbContext context)
    {
        await SeedCategoriesAsync(context);
        await SeedProductsAsync(context);
        await SeedRolesAsync(context);
        await SeedUsersAsync(context);
        await SeedUserRolesAsync(context);
        await SeedDiscountsAsync(context);
    }

    private static async Task SeedCategoriesAsync(ApplicationDbContext context)
    {
        if (!await context.Categories.AnyAsync())
        {
            try
            {
                await context.Categories.AddRangeAsync(InitialData.Categories);
                await context.SaveChangesAsync();
            }
            catch
            {
            }
        }
    }

    private static async Task SeedProductsAsync(ApplicationDbContext context)
    {
        if (!await context.Products.AnyAsync())
        {
            try
            {
                await context.Products.AddRangeAsync(InitialData.Products);
                await context.SaveChangesAsync();
            }
            catch
            {
            }
        }
    }

    private static async Task SeedRolesAsync(ApplicationDbContext context)
    {
        if (!await context.Roles.AnyAsync())
        {
            try
            {
                await context.Roles.AddRangeAsync(InitialData.Roles);
                await context.SaveChangesAsync();
            }
            catch
            {
            }
        }
    }

    private static async Task SeedUsersAsync(ApplicationDbContext context)
    {
        if (!await context.Users.AnyAsync())
        {
            try
            {
                await context.Users.AddRangeAsync(InitialData.Users);
                await context.SaveChangesAsync();
            }
            catch
            {
            }
        }
    }

    private static async Task SeedUserRolesAsync(ApplicationDbContext context)
    {
        if (!await context.UserRoles.AnyAsync())
        {
            try
            {
                await context.UserRoles.AddRangeAsync(InitialData.UserRoles);
                await context.SaveChangesAsync();
            }
            catch
            {
            }
        }
    }

    private static async Task SeedDiscountsAsync(ApplicationDbContext context)
    {
        if (!await context.Discounts.AnyAsync())
        {
            try
            {
                await context.Discounts.AddRangeAsync(InitialData.Discounts);
                await context.SaveChangesAsync();
            }
            catch
            {
            }
        }
    }
}