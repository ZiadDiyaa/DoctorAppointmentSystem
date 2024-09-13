using DoctorAppointmentSystem.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DoctorAppointmentSystem.Core
{
    public static class SeedData
    {
        public static async Task Initialize(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<Users>>();  // Use Users instead of IdentityUser

            // Seed Roles
            string[] roleNames = { "Admin", "Doctor", "Patient" };

            foreach (var roleName in roleNames)
            {
                if (!await roleManager.RoleExistsAsync(roleName))
                {
                    await roleManager.CreateAsync(new IdentityRole(roleName));
                }
            }

            // Seed Admin User
            var adminEmail = "admin@admin.com";
            var adminPassword = "Test1234,";
            var adminFullName = "Admin User";  // Add FullName

            if (await userManager.FindByEmailAsync(adminEmail) == null)
            {
                var adminUser = new Users
                {
                    UserName = adminEmail,
                    Email = adminEmail,
                    FullName = adminFullName  // Set FullName
                };

                var result = await userManager.CreateAsync(adminUser, adminPassword);
                
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(adminUser, "Admin");
                }
            }

            // Seed Doctor User
            var doctorEmail = "doctor@hospital.com";
            var doctorPassword = "Test1234,";
            var doctorFullName = "Doctor User";  // Add FullName

            if (await userManager.FindByEmailAsync(doctorEmail) == null)
            {
                var doctorUser = new Users
                {
                    UserName = doctorEmail,
                    Email = doctorEmail,
                    FullName = doctorFullName  // Set FullName
                };

                var result = await userManager.CreateAsync(doctorUser, doctorPassword);
                
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(doctorUser, "Doctor");
                }
            }
        }
    }
}