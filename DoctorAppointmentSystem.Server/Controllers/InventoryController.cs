using DoctorAppointmentSystem.Application;
using DoctorAppointmentSystem.Application.DTOs;
using DoctorAppointmentSystem.Application.InventoryManagement;
using Microsoft.AspNetCore.Mvc;

namespace DoctorAppointmentSystem.Server.Controllers;
public class InventoryController: Controller
{
 private readonly IManageInventory _manageInventory;
 
 public InventoryController(IManageInventory manageInventory)
 {
     _manageInventory = manageInventory;
 }
 
    [HttpGet("{inventoryID}")]
    public IActionResult GetInventory(int inventoryID)
    {
        ResultObject<InventoryDTO> result = _manageInventory.GetInventory(inventoryID);
        
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
    public IActionResult GetAllInventories()
    {
        ResultObject<ICollection<InventoryDTO>> result = _manageInventory.GetAllInventory();
        
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
    public IActionResult AddInventory(InventoryDTO inventoryDTO)
    {
        ResultObject<bool> result = _manageInventory.AddInventory(inventoryDTO);
        
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
    public IActionResult UpdateInventory(InventoryDTO inventoryDTO)
    {
        ResultObject<bool> result = _manageInventory.UpdateInventory(inventoryDTO);
        
        if (result.Succeeded)
        {
            return View(result.Result);
        }
        else
        {
            return View("Error", result.Messages);
        }
    }
    
    [HttpDelete("{inventoryID}")]
    public IActionResult DeleteInventory(int inventoryID)
    {
        ResultObject<bool> result = _manageInventory.DeleteInventory(inventoryID);
        
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