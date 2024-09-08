namespace DoctorAppointmentSystem.Application.DTOs;

public class AppointmentDTO
{
    public int AppointmentID { get; set; }
    
    public int PatientID { get; set; }  
    
    public int DoctorID { get; set; }
    
    public DateTime AppointmentDate { get; set; }
    
    public DateTime StartTime { get; set; }
    
    // public DateTime EndTime { get; set; }
    
    // public string TreatmentType { get; set; }
    
    public string? Status { get; set; }
}