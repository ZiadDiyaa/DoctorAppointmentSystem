using DoctorAppointmentSystem.Application;
using DoctorAppointmentSystem.Application.ConsumableMangement;
using DoctorAppointmentSystem.Application.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace DoctorAppointmentSystem.Server.Controllers;
[Route("Consumable")]
public class ConsumableController: Controller
{
    private readonly IManageConsumable _manageConsumable;
    
    public ConsumableController(IManageConsumable manageConsumable)
    {
        _manageConsumable = manageConsumable;
    }
    
    [HttpGet("{consumableID}")]
    [Route("GetConsumable")]
    public IActionResult GetConsumable(int consumableID)
    {
        ResultObject<ConsumableDTO> result = _manageConsumable.GetConsumable(consumableID);
        
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
    [Route("GetAllConsumables")]
    public IActionResult GetAllConsumables()
    {
        ResultObject<ICollection<ConsumableDTO>> result = _manageConsumable.GetAllConsumables();
        
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
    [Route("AddConsumable")]
    public IActionResult AddConsumable(ConsumableDTO consumableDTO)
    {
        ResultObject<bool> result = _manageConsumable.AddConsumable(consumableDTO);
        
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
    [Route("UpdateConsumable")]
    public IActionResult UpdateConsumable(ConsumableDTO consumableDTO)
    {
        ResultObject<bool> result = _manageConsumable.UpdateConsumable(consumableDTO);
        
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
    [Route("DeleteConsumable")]
    public IActionResult DeleteConsumable(int consumableID)
    {
        ResultObject<bool> result = _manageConsumable.DeleteConsumable(consumableID);
        
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