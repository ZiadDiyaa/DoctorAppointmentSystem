using DoctorAppointmentSystem.Application.DTOs;

namespace DoctorAppointmentSystem.Application.ConsumableMangement;

public interface IManageConsumable
{
    ResultObject<ConsumableDTO> GetConsumable(int consumableID);
    
    ResultObject<ICollection<ConsumableDTO>> GetAllConsumables();
    
    ResultObject<bool> AddConsumable(ConsumableDTO consumableDTO);
    
    ResultObject<bool> UpdateConsumable(ConsumableDTO consumableDTO);
    
    ResultObject<bool> DeleteConsumable(int consumableID);
    
    
}