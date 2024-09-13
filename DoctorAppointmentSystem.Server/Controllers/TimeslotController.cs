using DoctorAppointmentSystem.Application;
using DoctorAppointmentSystem.Application.DTOs;
using DoctorAppointmentSystem.Application.TimeslotManagement;
using Microsoft.AspNetCore.Mvc;

namespace DoctorAppointmentSystem.Server;
[Route("Timeslot")]
public class TimeslotController: Controller
{
    private readonly IManageTimeslot _manageTimeslot;
    
    public TimeslotController(IManageTimeslot manageTimeslot)
    {
        _manageTimeslot = manageTimeslot;
    }
    
    [HttpGet("{timeslotID}")]
    [Route("GetTimeslot")]
    public IActionResult GetTimeslot(int timeslotID)
    {
        ResultObject<TimeSlotDTO> result = _manageTimeslot.GetTimeSlot(timeslotID);
        
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
    [Route("GetAllTimeslots")]
    public IActionResult GetAllTimeslots()
    {
        ResultObject<ICollection<TimeSlotDTO>> result = _manageTimeslot.GetAllTimeSlots();
        
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
    [Route("AddTimeslot")]
    public IActionResult AddTimeslot(TimeSlotDTO timeslotDTO)
    {
        ResultObject<bool> result = _manageTimeslot.AddTimeSlot(timeslotDTO);
        
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
    [Route("UpdateTimeslot")]
    public IActionResult UpdateTimeslot(TimeSlotDTO timeslotDTO)
    {
        ResultObject<bool> result = _manageTimeslot.UpdateTimeSlot(timeslotDTO);
        
        if (result.Succeeded)
        {
            return View(result.Result);
        }
        else
        {
            return View("Error" );
        }
    }
    
    [HttpDelete("{timeslotID}")]
    [Route("DeleteTimeslot")]
    public IActionResult DeleteTimeslot(int timeslotID)
    {
        ResultObject<bool> result = _manageTimeslot.DeleteTimeSlot(timeslotID);
        
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