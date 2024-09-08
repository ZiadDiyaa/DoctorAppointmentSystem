using System.ComponentModel.DataAnnotations;

namespace DoctorAppointmentSystem.Core.Entities;

public class Patient
{
    public int PatientID { get; set; }
    [Required]
    public string FirstName { get; set; }
    [Required]

    public string LastName { get; set; }
    [Required]

    public DateTime DateOfBirth { get; set; }
    
    public string Email { get; set; }
    [Required]

    public string PhoneNumber { get; set; }
    [Required]

    public string Address { get; set; }
    
    public string MedicalHistory { get; set; }
    [Required]

    public int AccountID { get; set; }
    
    public virtual AccountDetails Account { get; set; }
    
    public virtual ICollection<Appointment> Appointments { get; set; }
    
    public virtual ICollection<TreatmentRecord> TreatmentRecords { get; set; }
}