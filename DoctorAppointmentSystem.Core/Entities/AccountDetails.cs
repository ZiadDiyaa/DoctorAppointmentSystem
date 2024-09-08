using System.ComponentModel.DataAnnotations;

namespace DoctorAppointmentSystem.Core.Entities;

public class AccountDetails
{
    [Key,Required]
    public int AccountID { get; set; }
    [Required]

    public string Username { get; set; }
    [Required]

    public string PasswordHash { get; set; }
    [Required]

    public string Email { get; set; }
    [Required]

    public DateTime CreatedDate { get; set; }

    public DateTime? LastLoginDate { get; set; }

    public virtual Patient Patient { get; set; }
    
    public virtual Doctor Doctor { get; set; }
    
    public virtual Admin Admin { get; set; }
}