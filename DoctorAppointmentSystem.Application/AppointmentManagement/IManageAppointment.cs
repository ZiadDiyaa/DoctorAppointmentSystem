using DoctorAppointmentSystem.Application.DTOs;

namespace DoctorAppointmentSystem.Application.AppointmentManagement;

public interface IManageAppointment
{
    ResultObject<AppointmentDTO> GetAppointment(int appointmentID);
    
    ResultObject<ICollection<AppointmentDTO>> GetAllAppointments(int doctorID);
    
    ResultObject<ICollection<AppointmentDTO>> GetAllAppointments(int doctorID, int patientID);
    
    ResultObject<bool> AddAppointment(AppointmentDTO appointmentDTO);
    
    ResultObject<bool> UpdateAppointment(AppointmentDTO appointmentDTO);
    
    ResultObject<bool> DeleteAppointment(int appointmentID);
    
    
}