namespace DoctorAppointmentSystem.Application.DTOs;

public class DoctorDTO
{
    public int DoctorID { get; set; }
    
    public string FirstName { get; set; }

    public string LastName { get; set; }
    
    public DateTime DateOfBirth { get; set; }

    public string Specialization { get; set; }
    
public string PracticeName { get; set; }    

public string City { get; set; }

public string Area { get; set; }

public string Address { get; set; }

    public string Rating { get; set; }
    
    public string Email { get; set; }

    public string PhoneNumber { get; set; }

    public int AccountID { get; set; }
    
    public bool IsAvailable { get; set; }
    
    public ICollection<AppointmentDTO> Appointments { get; set; }
    
    
}