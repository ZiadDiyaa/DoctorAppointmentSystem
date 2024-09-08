using DoctorAppointmentSystem.Application;
using DoctorAppointmentSystem.Application.DTOs;
using DoctorAppointmentSystem.Application.TimeslotManagement;
using Microsoft.AspNetCore.Mvc;

namespace DoctorAppointmentSystem.Server;
public class TimeslotController: Controller
{
    private readonly IManageTimeslot _manageTimeslot;
    
    public TimeslotController(IManageTimeslot manageTimeslot)
    {
        _manageTimeslot = manageTimeslot;
    }
    
    [HttpGet("{timeslotID}")]
    public IActionResult GetTimeslot(int timeslotID)
    {
        ResultObject<TimeSlotDTO> result = _manageTimeslot.GetTimeSlot(timeslotID);
        
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
    public IActionResult GetAllTimeslots()
    {
        ResultObject<ICollection<TimeSlotDTO>> result = _manageTimeslot.GetAllTimeSlots();
        
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
    public IActionResult AddTimeslot(TimeSlotDTO timeslotDTO)
    {
        ResultObject<bool> result = _manageTimeslot.AddTimeSlot(timeslotDTO);
        
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
    public IActionResult UpdateTimeslot(TimeSlotDTO timeslotDTO)
    {
        ResultObject<bool> result = _manageTimeslot.UpdateTimeSlot(timeslotDTO);
        
        if (result.Succeeded)
        {
            return View(result.Result);
        }
        else
        {
            return View("Error", result.Messages);
        }
    }
    
    [HttpDelete("{timeslotID}")]
    public IActionResult DeleteTimeslot(int timeslotID)
    {
        ResultObject<bool> result = _manageTimeslot.DeleteTimeSlot(timeslotID);
        
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