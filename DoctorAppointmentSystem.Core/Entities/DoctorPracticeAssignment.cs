using System.ComponentModel.DataAnnotations;

namespace DoctorAppointmentSystem.Core.Entities;

public class DoctorPracticeAssignment
{
    
    public int DoctorPracticeAssignmentID { get; set; }
    [Required]
    public int DoctorID { get; set; }
    
    public virtual Doctor Doctor { get; set; }
    [Required]
    public int PracticeID { get; set; }
    
    public virtual DoctorPractice Practice { get; set; }
}