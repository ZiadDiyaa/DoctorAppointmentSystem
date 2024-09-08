using System.ComponentModel.DataAnnotations;

namespace DoctorAppointmentSystem.Core.ViewModels;

public class VerifyEmailViewModel
{
    [Required(ErrorMessage = "Email is required")]
    [EmailAddress]
    public string Email { get; set; }
}