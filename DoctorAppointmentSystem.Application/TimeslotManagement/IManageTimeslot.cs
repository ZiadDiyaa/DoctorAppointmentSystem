using DoctorAppointmentSystem.Application.DTOs;

namespace DoctorAppointmentSystem.Application.TimeslotManagement;

public interface IManageTimeslot
{
    ResultObject<TimeSlotDTO> GetTimeSlot(int timeSlotID);
    
    ResultObject<ICollection<TimeSlotDTO>> GetAllTimeSlots();
    
    ResultObject<bool> AddTimeSlot(TimeSlotDTO timeSlotDTO);
    
    ResultObject<bool> UpdateTimeSlot(TimeSlotDTO timeSlotDTO);
    
    ResultObject<bool> DeleteTimeSlot(int TimeslotID);
    
    
}