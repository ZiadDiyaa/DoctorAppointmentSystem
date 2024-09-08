using System.ComponentModel.DataAnnotations;

namespace DoctorAppointmentSystem.Core.Entities;

public class Appointment
{
    public int AppointmentID { get; set; }
    [Required]
    public int PatientID { get; set; }  
    
    public virtual Patient Patient { get; set; }
    [Required]

    public int DoctorID { get; set; }
    
    public virtual Doctor Doctor { get; set; }
    [Required]

    public DateTime AppointmentDate { get; set; }
    [Required]
    public DateTime StartTime { get; set; }
    
    public DateTime EndTime { get; set; }
    
    public string TreatmentType { get; set; }
    
    public string Status { get; set; }
}