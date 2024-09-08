using DoctorAppointmentSystem.Core;
using DoctorAppointmentSystem.EF;
using DoctorAppointmentSystem.Application;
using DoctorAppointmentSystem.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using IdentityDbContext = DoctorAppointmentSystem.Core.IdentityDbContext;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddMvc(options => options.EnableEndpointRouting = false);

builder.Services.AddControllers();
builder.Services.AddControllersWithViews();

var connectionString= builder.Configuration.GetConnectionString("DefaultConnection") ?? "";

DoctorAppointmentSystem.Core.Configure.ConfigureServices(builder.Services, connectionString);

builder.Services.AddDbContext<IdentityDbContext>(options => options.UseSqlServer(connectionString));

// builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
//     .AddRoles<IdentityRole>()
//     .AddEntityFrameworkStores<IdentityDbContext>();


builder.Services.AddIdentity<Users, IdentityRole>(options =>
    {
        options.Password.RequireNonAlphanumeric = false;
        options.Password.RequiredLength = 8;
        options.Password.RequireUppercase = false;
        options.Password.RequireLowercase = false;
        options.User.RequireUniqueEmail = true;
        options.SignIn.RequireConfirmedAccount = false;
        options.SignIn.RequireConfirmedEmail = false;
        options.SignIn.RequireConfirmedPhoneNumber = false;
    })
    .AddEntityFrameworkStores<IdentityDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Admin", authBuilder =>
    {
        authBuilder.RequireRole("Admin");
    });
});

DoctorAppointmentSystem.EF.Configure.ConfigureServices(builder.Services);
DoctorAppointmentSystem.Application.Configure.ConfigureService(builder.Services);

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseMvc();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Booking}/{action=Create}/{id?}");

// Uncomment if you want to use Swagger in development
// if (app.Environment.IsDevelopment())
// {
//     app.UseSwagger();
//     app.UseSwaggerUI();
// }

// Role seeding

// using (var scope = app.Services.CreateScope())
// {
//     var roleManager= scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
//     
//     var roles = new [] {"Admin", "Doctor", "Patient"};
//
//     foreach (var role in roles)
//     {
//         if (!await roleManager.RoleExistsAsync(role))
//             await roleManager.CreateAsync(new IdentityRole(role));
//     }
// }
//
// using (var scope = app.Services.CreateScope())
// {
//     var userManager= scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();
//
//     string email = "admin@admin.com";
//     string password = "Test1234,";
//     if (await userManager.FindByEmailAsync(email) == null)
//     {
//         var user = new IdentityUser();
//         user.UserName = email;
//         user.Email = email;
//         await userManager.CreateAsync(user, password);
//         userManager.AddToRoleAsync(user, "Admin");
//     }
// }
// using (var scope = app.Services.CreateScope())
// {
//     var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
//
//     foreach (var role in Enum.GetValues(typeof(UsersRoles)).Cast<UsersRoles>())
//     {
//         var roleName = role.ToString();
//         if (!await roleManager.RoleExistsAsync(roleName))
//         {
//             await roleManager.CreateAsync(new IdentityRole(roleName));
//         }
//     }
// }

app.Run();