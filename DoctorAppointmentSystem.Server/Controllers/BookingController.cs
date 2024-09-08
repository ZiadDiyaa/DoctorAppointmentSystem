using DoctorAppointmentSystem.Application.DoctorMangement;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DoctorAppointmentSystem.Server.Controllers;
public class BookingController: Controller
{

    private readonly IManageDoctor _manageDoctor;

    public BookingController(IManageDoctor manageDoctor)
    {
        _manageDoctor = manageDoctor;
    }
    public IActionResult Index()
    {
        var doctors= _manageDoctor.GetAllDoctors();
        return View(doctors);
    }

    public IActionResult Create()
    {
        return View("Create");
    }
}