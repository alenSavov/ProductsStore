using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using ProductsStore.Data;
using ProductsStore.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ProductsStore.Infrastructure.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder SeedData(this IApplicationBuilder builder)
        {
            using (var serviceScope =
                builder.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var dbContext = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();
                var userManager = serviceScope.ServiceProvider.GetService<UserManager<AppUser>>();
                var roleManager = serviceScope.ServiceProvider.GetService<RoleManager<IdentityRole>>();

                dbContext.Database.Migrate();
                SeedRequiredData(dbContext, userManager, roleManager).GetAwaiter().GetResult();
            }

            return builder;
        }

        private static async Task SeedRequiredData(ApplicationDbContext dbContext,
           UserManager<AppUser> userManager,
           RoleManager<IdentityRole> roleManager)
        {
            await SeedCategories(dbContext);
            await SeedDefaultRoles(roleManager);
            await SeedUsers(userManager, dbContext);
        }

        private static async Task SeedUsers(UserManager<AppUser> userManager, ApplicationDbContext dbContext)
        {
            if (!dbContext.Users.Any())
            {
                var allUsers = new List<AppUser>();
                for (int i = 1; i <= 2; i++)
                {
                    var user = new AppUser
                    {
                        Email = $"test{i}@test.com",
                        UserName = $"test{i}@test.com",
                        EmailConfirmed = true
                    };

                    allUsers.Add(user);
                }

                foreach (var user in allUsers)
                {
                    await userManager.CreateAsync(user, "test123");
                }

                var admin = new AppUser
                {
                    Email = "admin@admin.com",
                    UserName = "admin@admin.com",
                    EmailConfirmed = true
                };

                await userManager.CreateAsync(admin, "admin123");
                await userManager.AddToRoleAsync(admin, WebConstants.AdministratorRole);
            }
        }

        private static async Task SeedDefaultRoles(RoleManager<IdentityRole> roleManager)
        {
            var roleExist = await roleManager.RoleExistsAsync(WebConstants.AdministratorRole);

            if (!roleExist)
            {
                await roleManager.CreateAsync(new IdentityRole(WebConstants.AdministratorRole));
            }
        }

        private static async Task SeedCategories(ApplicationDbContext dbContext)
        {
            if (!dbContext.Categories.Any())
            {
                var categories = File.ReadAllText(WebConstants.CategoriesPath);

                var deserializedCategoriesWithSubCategories =
                    JsonConvert.DeserializeObject<CategoryDto[]>(categories);

                var allCategories = deserializedCategoriesWithSubCategories.Select(deserializedCategory => new Category
                {
                    Name = deserializedCategory.Name,
                    SubCategories = deserializedCategory.SubCategoryNames.Select(deserializedSubCategory =>
                        new SubCategory
                        {
                            Name = deserializedSubCategory.Name
                        }).ToList()
                }).ToList();

                await dbContext.AddRangeAsync(allCategories);
                await dbContext.SaveChangesAsync();
            }
        }
    }

    internal class CategoryDto
    {
        public string Name { get; set; }

        public SubCategoryDto[] SubCategoryNames { get; set; }
    }

    internal class SubCategoryDto
    {
        public string Name { get; set; }
    }
}
