using DoctorAppointmentSystem.Application;
using DoctorAppointmentSystem.Application.DoctorMangement;
using DoctorAppointmentSystem.Application.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace DoctorAppointmentSystem.Server.Controllers;
public class DoctorController: Controller
{
    private readonly IManageDoctor _manageDoctor;
    
    public DoctorController(IManageDoctor manageDoctor)
    {
        _manageDoctor = manageDoctor;
    }
    
    [HttpGet("{doctorID}")]
    public IActionResult GetDoctor(int doctorID)
    {
        ResultObject<DoctorDTO> result = _manageDoctor.GetDoctor(doctorID);
        
        if (result.Succeeded)
        {
            return View(result.Result);
        }
        else
        {
            return View("Error");
        }
    }
    
    [HttpGet]
    [Route("GetAllDoctors")]
    public IActionResult GetAllDoctors()
    {
        ResultObject<ICollection<DoctorDTO>> result = _manageDoctor.GetAllDoctors();
        
        if (result.Succeeded)
        {
            return View(result.Result);
        }
        else
        {
            return View("Error");
        }
    }
    
    [HttpPost]
    public IActionResult AddDoctor(DoctorDTO doctorDTO)
    {
        ResultObject<bool> result = _manageDoctor.AddDoctor(doctorDTO);
        
        if (result.Succeeded)
        {
            return View(result.Result);
        }
        else
        {
            return View("Error");
        }
    }
    
    [HttpPut]
    public IActionResult UpdateDoctor(DoctorDTO doctorDTO)
    {
        ResultObject<bool> result = _manageDoctor.UpdateDoctor(doctorDTO);
        
        if (result.Succeeded)
        {
            return View(result.Result);
        }
        else
        {
            return View("Error");
        }
    }
    
    [HttpDelete]
    public IActionResult DeleteDoctor(int doctorID)
    {
        ResultObject<bool> result = _manageDoctor.DeleteDoctor(doctorID);
        
        if (result.Succeeded)
        {
            return View(result.Result);
        }
        else
        {
            return View("Error");
        }
    }
    
    
    [HttpGet]
    [Route("GetAvailableDoctors")]
    public IActionResult GetAvailableDoctors()
    {
        ResultObject<ICollection<DoctorDTO>> result = _manageDoctor.GetAvailableDoctors();
        
        if (result.Succeeded)
        {
            return View(result.Result);
        }
        else
        {
            return View("Error");
        }
    }
    
}