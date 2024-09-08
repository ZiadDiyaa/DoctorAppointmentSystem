using DoctorAppointmentSystem.Application.DTOs;

namespace DoctorAppointmentSystem.Application;

public interface IManageAdmin
{
    ResultObject<bool> AddAdmin(AdminDTO adminDTO);
    
    ResultObject<bool> UpdateAdmin(AdminDTO adminDTO);
    
    ResultObject<bool> DeleteAdmin(int adminID);
    
    ResultObject<bool> GetAdmin(int adminID);
    
    ResultObject<ICollection<AdminDTO>> GetAllAdmins();
    
        
}