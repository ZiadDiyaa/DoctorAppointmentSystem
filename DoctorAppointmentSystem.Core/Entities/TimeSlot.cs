using System.ComponentModel.DataAnnotations;

namespace DoctorAppointmentSystem.Core.Entities;

public class TimeSlot
{
    public int TimeSlotID { get; set; }
    [Required]

    public int DoctorID { get; set; }
    
    public virtual Doctor Doctor { get; set; }
    [Required]

    public DateTime StartTime { get; set; }
    [Required]

    public DateTime EndTime { get; set; }
    [Required]

    public bool isAvailable { get; set; }
}