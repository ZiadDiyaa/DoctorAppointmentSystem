namespace DoctorAppointmentSystem.Application.DTOs;

public class AdminDTO
{
    public int AdminID { get; set; }
    
    public string FirstName { get; set; }
    
    public string LastName { get; set; }
    
    public DateTime DateOfBirth { get; set; }
    
    public string Email { get; set; }
    
    public string PhoneNumber { get; set; }
    
    public int AccountID { get; set; }
    
    public int? PracticeID { get; set; }
    
    public int? InventoryID { get; set; }
    
}