using DoctorAppointmentSystem.Application;
using DoctorAppointmentSystem.Application.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace DoctorAppointmentSystem.Server.Controllers;
public class AdminController: Controller
{

    private readonly IManageAdmin _manageAdmin;
    
    public AdminController(IManageAdmin manageAdmin)
    {
        _manageAdmin = manageAdmin;
    }
    
    [HttpGet]
    [Route("GetAdmin")]
    public IActionResult GetAdmin(int adminID)
    {
        ResultObject<bool> result = _manageAdmin.GetAdmin(adminID);
        if (result.Succeeded)
        {
            return Ok(result.Result);
        }
        else
        {
            return BadRequest(result.Messages);
        }
    }
    
    [HttpGet]
    [Route("GetAllAdmins")]

    public IActionResult GetAllAdmins()
    {
        ResultObject<ICollection<AdminDTO>> result = _manageAdmin.GetAllAdmins();
        if (result.Succeeded)
        {
            return Ok(result.Result);
        }
        else
        {
            return BadRequest(result.Messages);
        }
    }
    
    [HttpPost]  
    [Route("AddAdmin")]

    public IActionResult AddAdmin(AdminDTO adminDTO)
    {
        ResultObject<bool> result = _manageAdmin.AddAdmin(adminDTO);
        if (result.Succeeded)
        {
            return Ok(result.Result);
        }
        else
        {
            return BadRequest(result.Messages);
        }
    }
    
    [HttpPut]
    [Route("UpdateAdmin")]

    public IActionResult UpdateAdmin(AdminDTO adminDTO)
    {
        ResultObject<bool> result = _manageAdmin.UpdateAdmin(adminDTO);
        if (result.Succeeded)
        {
            return Ok(result.Result);
        }
        else
        {
            return BadRequest(result.Messages);
        }
    }
    
    [HttpDelete]
    [Route("DeleteAdmin")]

    public IActionResult DeleteAdmin(int adminID)
    {
        ResultObject<bool> result = _manageAdmin.DeleteAdmin(adminID);
        if (result.Succeeded)
        {
            return Ok(result.Result);
        }
        else
        {
            return BadRequest(result.Messages);
        }
    }

}