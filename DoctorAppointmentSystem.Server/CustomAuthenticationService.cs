using System.Security.Policy;
using Azure;
using Azure.Core;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;

namespace DoctorAppointmentSystem.Server;

public class CustomAuthenticationService
{
    private readonly IHttpContextAccessor _contextAccessor;


    public CustomAuthenticationService(IHttpContextAccessor contextAccessor)
    {
        _contextAccessor = contextAccessor;
    }


    public async Task CustomSignoutAsync()
    {
        await _contextAccessor.HttpContext.SignOutAsync(IdentityConstants.ApplicationScheme);


        if (_contextAccessor.HttpContext.Request.Cookies.Count > 0)
        {
            foreach (var cookie in _contextAccessor.HttpContext.Request.Cookies.Keys)
            {
                _contextAccessor.HttpContext.Response.Cookies.Delete(cookie);
            }
        }
        
        var properties = new AuthenticationProperties
        {
            RedirectUri =_contextAccessor.HttpContext.Request.Path
        };
        
        await _contextAccessor.HttpContext.SignOutAsync(IdentityConstants.ApplicationScheme, properties);

        }
        

    }
