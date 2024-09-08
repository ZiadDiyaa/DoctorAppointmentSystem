using DoctorAppointmentSystem.Core.Entities;

namespace DoctorAppointmentSystem.Application.DTOs;

public class PatientDTO
{
    public int PatientID { get; set; }
    
    public string FirstName { get; set; }

    public string LastName { get; set; }

    public DateTime DateOfBirth { get; set; }
    
    public string Email { get; set; }

    public string PhoneNumber { get; set; }

    public string Address { get; set; }
    
    public string MedicalHistory { get; set; }

    public int AccountID { get; set; }
    
    
    public List<AppointmentDTO> Appointments { get; set; }
    
    
    
}