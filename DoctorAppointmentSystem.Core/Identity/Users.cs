using Microsoft.AspNetCore.Identity;

namespace DoctorAppointmentSystem.Core.Entities;

public class Users: IdentityUser
{
    public string FullName { get; set; }
}