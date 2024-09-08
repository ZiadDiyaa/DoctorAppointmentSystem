namespace DoctorAppointmentSystem.Application.DTOs;

public class AccountDetailsDTO
{
    public int AccountID { get; set; }
    
    public string UserName { get; set; }
    
    public string PasswordHash { get; set; }
    
    public string Email { get; set; }
    
    public DateTime CreatedDate { get; set; }
    
    public DateTime? LastLoginDate { get; set; }
    
    
}