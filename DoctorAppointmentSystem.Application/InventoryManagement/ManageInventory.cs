using DoctorAppointmentSystem.Application.DTOs;
using DoctorAppointmentSystem.Core.Entities;
using DoctorAppointmentSystem.Core.UOW;

namespace DoctorAppointmentSystem.Application.InventoryManagement;

public class ManageInventory: IManageInventory
{
    private readonly IUnitOfWork _unitOfWork;
    
    private readonly IBaseRepository _baseRepository;
    
    public ManageInventory(IUnitOfWork unitOfWork, IBaseRepository baseRepository)
    {
        _unitOfWork = unitOfWork;
        _baseRepository = baseRepository;
    }


    public ResultObject<InventoryDTO> GetInventory(int inventoryID)
    {
        ResultObject<InventoryDTO> result = new ResultObject<InventoryDTO>();

        try
        {
            InventoryDTO inventoryDTO = _baseRepository.Get<InventoryDTO>(inventoryID);

            if (inventoryDTO != null)
            {
                InventoryDTO inventoryResult = new InventoryDTO
                {
                    InventoryID = inventoryDTO.InventoryID,
                    Name = inventoryDTO.Name,
                    CurrentQuantity = inventoryDTO.CurrentQuantity,
                    AdminID = inventoryDTO.AdminID,
                    MaxQuantity = inventoryDTO.MaxQuantity,
                    LastUpdated = inventoryDTO.LastUpdated
                    
                };

                result.Result = inventoryResult;
                result.Succeeded = true;
            }
            else
            {
                result.Succeeded = false;
                result.AddMessage(MessageType.LogicalError, "Inventory not found.");
            }
        }
        catch (Exception ex)
        {
            result.Succeeded = false;
            result.AddMessage(MessageType.Exception, $"An error occurred while retrieving the inventory: {ex.Message}");
        }

        return result;
    }

    public ResultObject<ICollection<InventoryDTO>> GetAllInventory()
    {
        ResultObject<ICollection<InventoryDTO>> result = new ResultObject<ICollection<InventoryDTO>>();

        try
        {
            var inventoryEntities = _baseRepository.GetAll<Inventory>();

            if (inventoryEntities != null && inventoryEntities.Count > 0)
            {
                List<InventoryDTO> inventoryDTOs = new List<InventoryDTO>();

                foreach (var inventory in inventoryEntities)
                {
                    InventoryDTO inventoryDTO = new InventoryDTO
                    {
                        InventoryID = inventory.InventoryID,
                        Name = inventory.Name,
                        CurrentQuantity = inventory.CurrentQuantity,
                        AdminID = inventory.AdminID,
                        MaxQuantity = inventory.MaxQuantity,
                        LastUpdated = inventory.LastUpdated
                    };

                    inventoryDTOs.Add(inventoryDTO);
                }

                result.Result = inventoryDTOs;
                result.Succeeded = true;
            }
            else
            {
                result.Succeeded = false;
                result.AddMessage(MessageType.LogicalError, "No inventory found.");
            }
        }
        catch (Exception ex)
        {
            result.Succeeded = false;
            result.AddMessage(MessageType.Exception, $"An error occurred while retrieving the inventory: {ex.Message}");
        }

        return result;
    }

    public ResultObject<bool> AddInventory(InventoryDTO inventoryDTO)
    {
        ResultObject<bool> result = new ResultObject<bool>();

        try
        {
            Inventory inventory = new Inventory
            {
                Name = inventoryDTO.Name,
                CurrentQuantity = inventoryDTO.CurrentQuantity,
                AdminID = inventoryDTO.AdminID,
                MaxQuantity = inventoryDTO.MaxQuantity,
                LastUpdated = inventoryDTO.LastUpdated
            };

            _baseRepository.Add(inventory);
            _unitOfWork.Commit();
            result.Result = true;
            result.Succeeded = true;
        }
        catch (Exception ex)
        {
            result.Succeeded = false;
            result.AddMessage(MessageType.Exception, $"An error occurred while adding the inventory: {ex.Message}");
        }

        return result;
    }

    public ResultObject<bool> UpdateInventory(InventoryDTO inventoryDTO)
    {
        ResultObject<bool> result = new ResultObject<bool>();

        try
        {
            Inventory inventory = _baseRepository.Get<Inventory>(inventoryDTO.InventoryID);

            if (inventory != null)
            {
                inventory.InventoryID = inventoryDTO.InventoryID;
                inventory.Name = inventoryDTO.Name;
                inventory.CurrentQuantity = inventoryDTO.CurrentQuantity;
                inventory.AdminID = inventoryDTO.AdminID;
                inventory.MaxQuantity = inventoryDTO.MaxQuantity;
                inventory.LastUpdated = inventoryDTO.LastUpdated;

                _baseRepository.Update(inventory, inventory.InventoryID);
                _unitOfWork.Commit();
                result.Result = true;
                result.Succeeded = true;
            }
            else
            {
                result.Succeeded = false;
                result.AddMessage(MessageType.LogicalError, "Inventory not found.");
            }
        }
        catch (Exception ex)
        {
            result.Succeeded = false;
            result.AddMessage(MessageType.Exception, $"An error occurred while updating the inventory: {ex.Message}");
        }

        return result;
    }

    public ResultObject<bool> DeleteInventory(int inventoryID)
    {
        ResultObject<bool> result = new ResultObject<bool>();

        try
        {
            Inventory inventory = _baseRepository.Get<Inventory>(inventoryID);

            if (inventory != null)
            {
                _baseRepository.Delete(inventory);
                _unitOfWork.Commit();
                result.Result = true;
                result.Succeeded = true;
            }
            else
            {
                result.Succeeded = false;
                result.AddMessage(MessageType.LogicalError, "Inventory not found.");
            }
        }
        catch (Exception ex)
        {
            result.Succeeded = false;
            result.AddMessage(MessageType.Exception, $"An error occurred while deleting the inventory: {ex.Message}");
        }

        return result;
    }
}