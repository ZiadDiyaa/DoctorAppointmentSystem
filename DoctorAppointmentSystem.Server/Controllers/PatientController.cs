using DoctorAppointmentSystem.Application;
using DoctorAppointmentSystem.Application.DTOs;
using DoctorAppointmentSystem.Application.PatientManagement;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DoctorAppointmentSystem.Server.Controllers;
[Authorize("Admin")]
public class PatientController: Controller
{

    private readonly IManagePatient _managePatient;
    
    public PatientController(IManagePatient managePatient)
    {
        _managePatient = managePatient;
    }
    
    [HttpGet("{patientID}")]
    public IActionResult GetPatient(int patientID)
    {
        ResultObject<PatientDTO> result = _managePatient.GetPatient(patientID);
        
        if (result.Succeeded)
        {
            return View(result.Result);
        }
        else
        {
            return View("Error", result.Messages);
        }
    }
    
    [HttpGet]
    public IActionResult GetAllPatients()
    {
        ResultObject<ICollection<PatientDTO>> result = _managePatient.GetAllPatients();
        
        if (result.Succeeded)
        {
            return View(result.Result);
        }
        else
        {
            return View("Error", result.Messages);
        }
    }
    
    [HttpPost]
    public IActionResult AddPatient(PatientDTO patientDTO)
    {
        ResultObject<bool> result = _managePatient.AddPatient(patientDTO);
        
        if (result.Succeeded)
        {
            return View(result.Result);
        }
        else
        {
            return View("Error", result.Messages);
        }
    }
    
    [HttpPut]
    public IActionResult UpdatePatient(PatientDTO patientDTO)
    {
        ResultObject<bool> result = _managePatient.UpdatePatient(patientDTO);
        
        if (result.Succeeded)
        {
            return View(result.Result);
        }
        else
        {
            return View("Error", result.Messages);
        }
    }
    
    [HttpDelete]
    public IActionResult DeletePatient(int PatientID)
    {
        ResultObject<bool> result = _managePatient.DeletePatient(PatientID);
        
        if (result.Succeeded)
        {
            return View(result.Result);
        }
        else
        {
            return View("Error", result.Messages);
        }
    }
    
    
}