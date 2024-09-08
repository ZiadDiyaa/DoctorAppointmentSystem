namespace DoctorAppointmentSystem.Application.DTOs;

public class TimeSlotDTO
{
    public int TimeSlotID { get; set; }

    public int DoctorID { get; set; }
    
    public DateTime StartTime { get; set; }

    public DateTime EndTime { get; set; }

    public bool isAvailable { get; set; }
}