using DoctorAppointmentSystem.Application;
using DoctorAppointmentSystem.Application.DTOs;
using DoctorAppointmentSystem.Application.InventoryManagement;
using Microsoft.AspNetCore.Mvc;

namespace DoctorAppointmentSystem.Server.Controllers;
[Route("Inventory")]
public class InventoryController: Controller
{
 private readonly IManageInventory _manageInventory;
 
 public InventoryController(IManageInventory manageInventory)
 {
     _manageInventory = manageInventory;
 }
 
    [HttpGet("{inventoryID}")]
    [Route("GetInventory")]
    public IActionResult GetInventory(int inventoryID)
    {
        ResultObject<InventoryDTO> result = _manageInventory.GetInventory(inventoryID);
        
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
    [Route("GetAllInventories")]
    public IActionResult GetAllInventories()
    {
        ResultObject<ICollection<InventoryDTO>> result = _manageInventory.GetAllInventory();
        
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
    [Route("AddInventory")]
    public IActionResult AddInventory(InventoryDTO inventoryDTO)
    {
        ResultObject<bool> result = _manageInventory.AddInventory(inventoryDTO);
        
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
    [Route("UpdateInventory")]
    public IActionResult UpdateInventory(InventoryDTO inventoryDTO)
    {
        ResultObject<bool> result = _manageInventory.UpdateInventory(inventoryDTO);
        
        if (result.Succeeded)
        {
            return View(result.Result);
        }
        else
        {
            return View("Error" );
        }
    }
    
    [HttpDelete("{inventoryID}")]
    [Route("DeleteInventory")]
    public IActionResult DeleteInventory(int inventoryID)
    {
        ResultObject<bool> result = _manageInventory.DeleteInventory(inventoryID);
        
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