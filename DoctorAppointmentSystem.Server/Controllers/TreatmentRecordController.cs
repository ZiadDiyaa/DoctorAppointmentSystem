using DoctorAppointmentSystem.Application;
using DoctorAppointmentSystem.Application.DTOs;
using DoctorAppointmentSystem.Application.TreatmentRecordManagement;
using Microsoft.AspNetCore.Mvc;

namespace DoctorAppointmentSystem.Server;
[Route("TreatmentRecord")]
public class TreatmentRecordController: Controller
{
    private readonly IManageTreatmentRecord _manageTreatmentRecord;
    
    public TreatmentRecordController(IManageTreatmentRecord manageTreatmentRecord)
    {
        _manageTreatmentRecord = manageTreatmentRecord;
    }
    
    [HttpGet("{treatmentRecordID}")]
    [Route("GetTreatmentRecord")]
    public IActionResult GetTreatmentRecord(int treatmentRecordID)
    {
        ResultObject<TreatmentRecordDTO> result = _manageTreatmentRecord.GetTreatmentRecord(treatmentRecordID);
        
        if (result.Succeeded)
        {
            return View(result.Result);
        }
        else
        {
            return View("Error" );
        }
    }
    
    [HttpGet]
    [Route("GetAllTreatmentRecords")]
    public IActionResult GetAllTreatmentRecords()
    {
        ResultObject<ICollection<TreatmentRecordDTO>> result = _manageTreatmentRecord.GetAllTreatmentRecords();
        
        if (result.Succeeded)
        {
            return View(result.Result);
        }
        else
        {
            return View("Error" );
        }
    }
    
    [HttpPost]
    [Route("AddTreatmentRecord")]
    public IActionResult AddTreatmentRecord(TreatmentRecordDTO treatmentRecordDTO)
    {
        ResultObject<bool> result = _manageTreatmentRecord.AddTreatmentRecord(treatmentRecordDTO);
        
        if (result.Succeeded)
        {
            return View(result.Result);
        }
        else
        {
            return View("Error" );
        }
    }
    
    [HttpPut]
    [Route("UpdateTreatmentRecord")]
    public IActionResult UpdateTreatmentRecord(TreatmentRecordDTO treatmentRecordDTO)
    {
        ResultObject<bool> result = _manageTreatmentRecord.UpdateTreatmentRecord(treatmentRecordDTO);
        
        if (result.Succeeded)
        {
            return View(result.Result);
        }
        else
        {
            return View("Error" );
        }
    }
    
    [HttpDelete("{treatmentRecordID}")]
    [Route("DeleteTreatmentRecord")]
    public IActionResult DeleteTreatmentRecord(int treatmentRecordID)
    {
        ResultObject<bool> result = _manageTreatmentRecord.DeleteTreatmentRecord(treatmentRecordID);
        
        if (result.Succeeded)
        {
            return View(result.Result);
        }
        else
        {
            return View("Error" );
        }
    }
}