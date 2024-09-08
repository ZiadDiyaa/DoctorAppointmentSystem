using DoctorAppointmentSystem.Application.DTOs;
using DoctorAppointmentSystem.Core.UOW;

namespace DoctorAppointmentSystem.Application.ConsumableMangement;

public class ManageConsumable : IManageConsumable
{

    private readonly IUnitOfWork unitOfWork;

    private readonly IBaseRepository baseRepository;

    public ManageConsumable(IUnitOfWork unitOfWork, IBaseRepository baseRepository)
    {
        this.unitOfWork = unitOfWork;
        this.baseRepository = baseRepository;
    }

    public ResultObject<ConsumableDTO> GetConsumable(int consumableID)
    {
        ResultObject<ConsumableDTO> result = new ResultObject<ConsumableDTO>();

        try
        {
            Core.Entities.Consumable consumableEntity = baseRepository.Get<Core.Entities.Consumable>(consumableID);

            if (consumableEntity != null)
            {
                ConsumableDTO consumableDTO = new ConsumableDTO
                {
                    // ConsumableID = consumableEntity.ConsumableID,
                    Name = consumableEntity.Name,
                    Description = consumableEntity.Description,
                    Category = consumableEntity.Category,
                    UnitPrice = consumableEntity.UnitPrice,
                    QuantityInStock = consumableEntity.QuantityInStock,
                    ThresholdQuantity = consumableEntity.ThresholdQuantity,
                    DateAdded = DateTime.Now,
                    ExpirationDate = consumableEntity.ExpirationDate,
                    Barcode = consumableEntity.Barcode,
                    InventoryID = consumableEntity.InventoryID


                };

                result.Result = consumableDTO;
                result.Succeeded = true;
            }
            else
            {
                result.Succeeded = false;
                result.AddMessage(MessageType.LogicalError, "Consumable not found.");
            }
        }
        catch (Exception ex)
        {
            result.Succeeded = false;
            result.AddMessage(MessageType.Exception,
                $"An error occurred while retrieving the consumable: {ex.Message}");
        }

        return result;
    }

    public ResultObject<ICollection<ConsumableDTO>> GetAllConsumables()
    {
        ResultObject<ICollection<ConsumableDTO>> result = new ResultObject<ICollection<ConsumableDTO>>();

        try
        {
            ICollection<Core.Entities.Consumable>
                consumableEntities = baseRepository.GetAll<Core.Entities.Consumable>();

            if (consumableEntities != null)
            {
                List<ConsumableDTO> consumableDTOs = new List<ConsumableDTO>();

                foreach (Core.Entities.Consumable consumableEntity in consumableEntities)
                {
                    ConsumableDTO consumableDTO = new ConsumableDTO
                    {
                        // ConsumableID = consumableEntity.ConsumableID,
                        Name = consumableEntity.Name,
                        Description = consumableEntity.Description,
                        Category = consumableEntity.Category,
                        UnitPrice = consumableEntity.UnitPrice,
                        QuantityInStock = consumableEntity.QuantityInStock,
                        ThresholdQuantity = consumableEntity.ThresholdQuantity,
                        DateAdded = DateTime.Now,
                        ExpirationDate = consumableEntity.ExpirationDate,
                        Barcode = consumableEntity.Barcode,
                        InventoryID = consumableEntity.InventoryID
                    };

                    consumableDTOs.Add(consumableDTO);
                }

                result.Result = consumableDTOs;
                result.Succeeded = true;
            }
            else
            {
                result.Succeeded = false;
                result.AddMessage(MessageType.LogicalError, "No consumables found.");
            }
        }
        catch (Exception ex)
        {
            result.Succeeded = false;
            result.AddMessage(MessageType.Exception,
                $"An error occurred while retrieving the consumables: {ex.Message}");
        }

        return result;
    }

    public ResultObject<bool> AddConsumable(ConsumableDTO consumableDTO)
    {
        ResultObject<bool> result = new ResultObject<bool>();

        try
        {
            Core.Entities.Consumable consumableEntity = new Core.Entities.Consumable
            {
                // ConsumableID = consumableDTO.ConsumableID,
                Name = consumableDTO.Name,
                Description = consumableDTO.Description,
                Category = consumableDTO.Category,
                UnitPrice = consumableDTO.UnitPrice,
                QuantityInStock = consumableDTO.QuantityInStock,
                ThresholdQuantity = consumableDTO.ThresholdQuantity,
                DateAdded = DateTime.Now,
                ExpirationDate = consumableDTO.ExpirationDate,
                Barcode = consumableDTO.Barcode,
                InventoryID = consumableDTO.InventoryID
            };
            result.Succeeded = true;
            result.Result = true;
            baseRepository.Add<Core.Entities.Consumable>(consumableEntity);
            unitOfWork.Commit();
        }
        catch (Exception)
        {
            result.Succeeded = false;
            result.AddMessage(MessageType.Exception, "An error occurred while adding the consumable");
        }

        return result;

    }

public ResultObject<bool> UpdateConsumable(ConsumableDTO consumableDTO)
    {
        ResultObject<bool> result = new ResultObject<bool>();

        if (consumableDTO == null)
        {
            result.Succeeded = false;
            result.AddMessage(MessageType.LogicalError, "No consumable data found");
        }

        try
        {
            Core.Entities.Consumable consumableEntity = baseRepository.Get<Core.Entities.Consumable>(consumableDTO.ConsumableID);
            if (consumableEntity != null)
            {
                consumableEntity.ConsumableID = consumableDTO.ConsumableID;
                consumableEntity.Name = consumableDTO.Name;
                consumableEntity.Description = consumableDTO.Description;
                consumableEntity.Category = consumableDTO.Category;
                consumableEntity.UnitPrice = consumableDTO.UnitPrice;
                consumableEntity.QuantityInStock = consumableDTO.QuantityInStock;
                consumableEntity.ThresholdQuantity = consumableDTO.ThresholdQuantity;
                consumableEntity.DateAdded = DateTime.Now;
                consumableEntity.ExpirationDate = consumableDTO.ExpirationDate;
                consumableEntity.Barcode = consumableDTO.Barcode;
                consumableEntity.InventoryID = consumableDTO.InventoryID;

                baseRepository.Update<Core.Entities.Consumable>(consumableEntity, consumableEntity.ConsumableID);
                unitOfWork.Commit();
                result.Succeeded = true;
                result.Result = true;
            }
            else
            {
                result.Succeeded = false;
                result.AddMessage(MessageType.LogicalError, "No consumable found.");
            }
        }
        catch (Exception)
        {
            result.Succeeded = false;
            result.AddMessage(MessageType.Exception, "An error occurred while updating the consumable");
        }

        return result;
    }

    public ResultObject<bool> DeleteConsumable(int consumableID)
    {
        ResultObject<bool> result = new ResultObject<bool>();

        try
        {
            Core.Entities.Consumable consumableEntity = baseRepository.Get<Core.Entities.Consumable>(consumableID);

            if (consumableEntity != null)
            {
                baseRepository.Delete<Core.Entities.Consumable>(consumableEntity);
                unitOfWork.Commit();
                result.Succeeded = true;
                result.Result = true;
            }
            else
            {
                result.Succeeded = false;
                result.AddMessage(MessageType.LogicalError, "No consumable found.");
            }
        }
        catch (Exception)
        {
            result.Succeeded = false;
            result.AddMessage(MessageType.Exception, "An error occurred while deleting the consumable");
        }

        return result;
    }
}