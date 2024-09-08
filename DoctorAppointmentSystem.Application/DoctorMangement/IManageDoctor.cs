using DoctorAppointmentSystem.Application.DTOs;

namespace DoctorAppointmentSystem.Application.DoctorMangement;

public interface IManageDoctor
{
    ResultObject<DoctorDTO> GetDoctor(int doctorID);
    
    ResultObject<ICollection<DoctorDTO>> GetAllDoctors();
    
    ResultObject<bool> AddDoctor(DoctorDTO doctorDTO);
    
    ResultObject<bool> UpdateDoctor(DoctorDTO doctorDTO);
    
    ResultObject<bool> DeleteDoctor(int doctorID);

    ResultObject<ICollection<DoctorDTO>> GetAvailableDoctors();

}