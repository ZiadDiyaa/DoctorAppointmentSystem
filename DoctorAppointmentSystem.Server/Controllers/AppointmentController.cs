using DoctorAppointmentSystem.Application;
using DoctorAppointmentSystem.Application.AppointmentManagement;
using DoctorAppointmentSystem.Application.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace DoctorAppointmentSystem.Server.Controllers;
[Route("Appointment")]
public class AppointmentController: Controller
{
    private readonly IManageAppointment _manageAppointment;
    
    public AppointmentController(IManageAppointment manageAppointment)
    {
        _manageAppointment = manageAppointment;
    }
    
    [HttpGet("{appointmentID}")]
    [Route("GetAppointment")]
    public IActionResult GetAppointment(int appointmentID)
    {
        ResultObject<AppointmentDTO> result = _manageAppointment.GetAppointment(appointmentID);
        
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
    [Route("GetAllApppointments")]
    public IActionResult GetAllAppointments(int patientID, int DoctorID)
    {
        ResultObject<ICollection<AppointmentDTO>> result = _manageAppointment.GetAllAppointments(patientID, DoctorID);
        
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
    [Route("AddAppointment")]
    public IActionResult AddAppointment(AppointmentDTO appointmentDTO)
    {
        ResultObject<bool> result = _manageAppointment.AddAppointment(appointmentDTO);
        
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
    [Route("UpdateAppointment")]
    public IActionResult UpdateAppointment(AppointmentDTO appointmentDTO)
    {
        ResultObject<bool> result = _manageAppointment.UpdateAppointment(appointmentDTO);
        
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
    [Route("DeleteAppointment")]
    public IActionResult DeleteAppointment(int appointmentID)
    {
        ResultObject<bool> result = _manageAppointment.DeleteAppointment(appointmentID);
        
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