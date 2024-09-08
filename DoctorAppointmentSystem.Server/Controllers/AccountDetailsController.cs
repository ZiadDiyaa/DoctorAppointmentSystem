using DoctorAppointmentSystem.Application;
using DoctorAppointmentSystem.Application.AccountDetails;
using DoctorAppointmentSystem.Application.DTOs;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace DoctorAppointmentSystem.Server.Controllers;
public class AccountDetailsController: Controller
{
    private readonly IManageAccountDetails _manageAccountDetails;
    
    public AccountDetailsController(IManageAccountDetails manageAccountDetails)
    {
        _manageAccountDetails = manageAccountDetails;
    }
    
    [HttpGet("{accountID}")]
    public IActionResult GetAccountDetails(int accountID)
    {
        ResultObject<AccountDetailsDTO> result = _manageAccountDetails.GetAccountDetails(accountID);
        
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
    public IActionResult GetAllAccountDetails()
    {
        ResultObject<ICollection<AccountDetailsDTO>> result = _manageAccountDetails.GetAllAccountDetails();
        
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
    public IActionResult AddAccountDetails(AccountDetailsDTO accountDetailsDTO)
    {
        ResultObject<bool> result = _manageAccountDetails.AddAccountDetails(accountDetailsDTO);
        
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
    public IActionResult UpdateAccountDetails(AccountDetailsDTO accountDetailsDTO)
    {
        ResultObject<bool> result = _manageAccountDetails.UpdateAccountDetails(accountDetailsDTO);
        
        if (result.Succeeded)
        {
            return View(result.Result);
        }
        else
        {
            return View("Error", result.Messages);
        }
    }
    
    [HttpDelete("{accountID}")]
    public IActionResult DeleteAccountDetails(int accountID)
    {
        ResultObject<bool> result = _manageAccountDetails.DeleteAccountDetails(accountID);
        
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