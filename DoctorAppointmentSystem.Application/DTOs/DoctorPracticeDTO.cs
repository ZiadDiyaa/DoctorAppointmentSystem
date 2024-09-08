namespace DoctorAppointmentSystem.Application.DTOs;

public class DoctorPracticeDTO
{
    public int PracticeID { get; set; }

    public string Name { get; set; }
    
    public string City { get; set; }
    
    public string Area { get; set; }

    public string Address { get; set; }

    public string PostalCode { get; set; }

    public string PhoneNumber { get; set; }
    
    public int? AdminID { get; set; }
    
}