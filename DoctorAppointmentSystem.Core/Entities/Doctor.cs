using System.ComponentModel.DataAnnotations;

namespace DoctorAppointmentSystem.Core.Entities;

public class Doctor
{
    public int DoctorID { get; set; }
    [Required]
    public string FirstName { get; set; }
    [Required]

    public string LastName { get; set; }
    [Required]

    public string Specialization { get; set; }
    
    public string Rating { get; set; }
    [Required]
    public DateTime DateOfBirth { get; set; }

    
    public string Email { get; set; }
    [Required]

    public string PhoneNumber { get; set; }
    [Required]

    public int AccountID { get; set; }
    
    public bool IsAvailable { get; set; }
    
    public virtual AccountDetails Account { get; set; }
    
    public virtual ICollection<Appointment> Appointments { get; set; }
    
    public virtual ICollection<TimeSlot> TimeSlots { get; set; }
    
    public virtual ICollection<TreatmentRecord> TreatmentRecords { get; set; }
    
    public virtual ICollection<DoctorPracticeAssignment> PracticeAssignments { get; set; }
    
    
}