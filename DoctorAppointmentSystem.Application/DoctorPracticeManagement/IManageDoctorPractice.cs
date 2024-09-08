using DoctorAppointmentSystem.Application.DTOs;

namespace DoctorAppointmentSystem.Application.DoctorPracticeManagement;

public interface IManageDoctorPractice
{
    ResultObject<DoctorPracticeDTO> GetDoctorPractice(int practiceID);
    
    ResultObject<ICollection<DoctorPracticeDTO>> GetAllDoctorPractices();
    
    ResultObject<bool> AddDoctorPractice(DoctorPracticeDTO doctorPracticeDTO);
    
    ResultObject<bool> UpdateDoctorPractice(DoctorPracticeDTO doctorPracticeDTO);
    
    ResultObject<bool> DeleteDoctorPractice(int practiceID);
    
    
    
}