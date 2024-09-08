using Microsoft.AspNetCore.Mvc;

namespace DoctorAppointmentSystem.Server.Controllers;

public class HomeController: Controller
{

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult About()
    {
        ViewData["Message"] = "Your application description page.";
        return View();
    }

    public IActionResult Contact()
    {
        ViewData["Message"] = "Your Contact Page.";
        return View();
    }

    public IActionResult Error()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }
    
    
    
}