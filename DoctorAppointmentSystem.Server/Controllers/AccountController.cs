using DoctorAppointmentSystem.Core.Entities;
using DoctorAppointmentSystem.Core.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace DoctorAppointmentSystem.Server.Controllers;

public class AccountController: Controller
{
    private readonly SignInManager<Users> signInManager;
    private readonly UserManager<Users> userManager;
    private readonly RoleManager<IdentityRole> roleManager;
    
    public AccountController(SignInManager<Users> signInManager, UserManager<Users> userManager, RoleManager<IdentityRole> roleManager)
    {
        this.signInManager = signInManager;
        this.userManager = userManager;
        this.roleManager = roleManager;
    }

    
    public IActionResult Login()
    {
     return View();

    }
    
    [HttpPost]
    public async Task<IActionResult> Login(LoginViewModel model)
    {
        // Log the beginning of the login attempt
        Console.WriteLine($"Login attempt for Email: {model.Email}");

        if (ModelState.IsValid)
        {
            // Log that the model is valid
            Console.WriteLine("ModelState is valid. Proceeding with login.");

            var result = await signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);

            // Log the result of the sign-in attempt
            Console.WriteLine($"PasswordSignInAsync result: {result.Succeeded}");

            if (result.Succeeded)
            {
                // Log successful login
                Console.WriteLine($"User {model.Email} successfully logged in.");
                return RedirectToAction("Index", "Home");
            }
            else
            {
                // Log failed login attempt
                Console.WriteLine($"Login failed for user {model.Email}. Invalid credentials.");
                ModelState.AddModelError("", "Email or password is incorrect.");
                return View(model);
            }
        }
        else
        {
            // Log ModelState errors
            Console.WriteLine("ModelState is invalid. Errors:");

            foreach (var state in ModelState)
            {
                foreach (var error in state.Value.Errors)
                {
                    Console.WriteLine($"Field: {state.Key}, Error: {error.ErrorMessage}");
                }
            }

            // Log that the model was invalid and return the view
            Console.WriteLine($"Login attempt for Email: {model.Email} failed due to invalid ModelState.");
        }

        // Return view with the invalid model
        return View(model);
    }
    
    
    public IActionResult Register()
    {
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> Register(RegisterViewModel model)
    {
        if (ModelState.IsValid)
        {
            Users users = new Users
            {
                FullName = model.Name,
                Email = model.Email,
                UserName = model.Email,
            };

            var result = await userManager.CreateAsync(users, model.Password);

            if (result.Succeeded)
            {
                return RedirectToAction("Login", "Account");
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                return View(model);
            }
        }
        return View(model);
    }

    //
    // public IActionResult VerifyEmail()
    // {
    //     return View();
    // }
    
    [HttpPost]
    public async Task<IActionResult> VerifyEmail(VerifyEmailViewModel model)
    {
        if (ModelState.IsValid)
        {
            var user = await userManager.FindByNameAsync(model.Email);

            if(user == null)
            {
                ModelState.AddModelError("", "Something went wrong!");
                return View(model);
            }
            else
            {
                return RedirectToAction("ChangePassword","Account", new {username = user.UserName});
            }
        }
        return View(model);
    }

    public IActionResult ChangePassword(string username)
    {
        if (string.IsNullOrEmpty(username))
        {
            return RedirectToAction("VerifyEmail", "Account");
        }
        return View(new ChangePasswordViewModel { Email= username });
    }

    [HttpPost]
    public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
    {
        if(ModelState.IsValid)
        {
            var user = await userManager.FindByNameAsync(model.Email);
            if(user != null)
            {
                var result = await userManager.RemovePasswordAsync(user);
                if (result.Succeeded)
                {
                    result = await userManager.AddPasswordAsync(user, model.NewPassword);
                    return RedirectToAction("Login", "Account");
                }
                else
                {

                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }

                    return View(model);
                }
            }
            else
            {
                ModelState.AddModelError("", "Email not found!");
                return View(model);
            }
        }
        else
        {
            ModelState.AddModelError("", "Something went wrong. try again.");
            return View(model);
        }
    }
    
    public async Task<IActionResult> Logout()
    {
        await signInManager.SignOutAsync();
        return RedirectToAction("Index", "Home");
    }
    
    [Authorize(Roles = "Admin")]
    [HttpGet]
    public IActionResult CreateRole()
    {
        return View();
    }

    [Authorize(Roles = "Admin")]
    [HttpPost]
    public async Task<IActionResult> CreateRole(string roleName)
    {
        if (!string.IsNullOrWhiteSpace(roleName))
        {
            var roleExist = await roleManager.RoleExistsAsync(roleName);
            if (!roleExist)
            {
                var result = await roleManager.CreateAsync(new IdentityRole(roleName));
                if (result.Succeeded)
                {
                    ViewBag.Message = "Role created successfully!";
                    return View(); 
                }
                ViewBag.Message = "Error creating the role!";
            }
            else
            {
                ViewBag.Message = "Role already exists.";
            }
        }
        else
        {
            ViewBag.Message = "Role name cannot be empty.";
        }
        return View();
    }
    
    [Authorize(Roles = "Admin")]
    [HttpGet]
    public IActionResult AssignRole()
    {
        return View(); // This will return the view with the form to assign a role to a user.
    }

    [Authorize(Roles = "Admin")]
    [HttpPost]
    public async Task<IActionResult> AssignRole(string email, string roleName)
    {
        var user = await userManager.FindByEmailAsync(email);
        if (user != null)
        {
            var roleExist = await roleManager.RoleExistsAsync(roleName);
            if (roleExist)
            {
                var result = await userManager.AddToRoleAsync(user, roleName);
                if (result.Succeeded)
                {
                    ViewBag.Message = "Role assigned successfully!";
                    return View();
                }
                ViewBag.Message = "Error assigning the role.";
            }
            else
            {
                ViewBag.Message = "Role does not exist.";
            }
        }
        else
        {
            ViewBag.Message = "User not found.";
        }
        return View();
    }
    
    

    
    

}