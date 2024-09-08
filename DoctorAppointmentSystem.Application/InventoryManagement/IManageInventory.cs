using DoctorAppointmentSystem.Application.DTOs;

namespace DoctorAppointmentSystem.Application.InventoryManagement;

public interface IManageInventory
{
    ResultObject<InventoryDTO> GetInventory(int inventoryID);
    
    ResultObject<ICollection<InventoryDTO>> GetAllInventory();
    
    ResultObject<bool> AddInventory(InventoryDTO inventoryDTO);
    
    ResultObject<bool> UpdateInventory(InventoryDTO inventoryDTO);
    
    ResultObject<bool> DeleteInventory(int inventoryID);
    
    
}