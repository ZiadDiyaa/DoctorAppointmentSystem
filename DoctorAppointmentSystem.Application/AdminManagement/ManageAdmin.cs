using DoctorAppointmentSystem.Application.DTOs;
using DoctorAppointmentSystem.Core.Entities;
using DoctorAppointmentSystem.Core.UOW;

namespace DoctorAppointmentSystem.Application;

public class ManageAdmin: IManageAdmin
{

    private readonly IBaseRepository _baseRepository;
    
    private readonly IUnitOfWork _unitOfWork;
    
    
    public ManageAdmin(IBaseRepository baseRepository)
    {
        _baseRepository = baseRepository;
        _unitOfWork = _unitOfWork;
    }
    public ResultObject<bool> AddAdmin(AdminDTO adminDTO)
    {
        ResultObject<bool> result = new ResultObject<bool>();
       if(adminDTO != null)
       {
        result.Succeeded = false;
        result.AddMessage(MessageType.LogicalError, "No admin data found");
       }

       try
       {
           AdminDTO admin= new AdminDTO
           {
                // AdminID = adminDTO.AdminID,
                FirstName = adminDTO.FirstName,
                LastName = adminDTO.LastName,
                Email = adminDTO.Email,
                PhoneNumber = adminDTO.PhoneNumber,
                // AccountID = adminDTO.AccountID,
                PracticeID = adminDTO.PracticeID,
                InventoryID = adminDTO.InventoryID
                
              };
           _baseRepository.Add<AdminDTO>(admin);
           _unitOfWork.Commit();
           result.Succeeded = true;
           result.Result = true;
       }
       catch(Exception){
              result.Succeeded = false;
              result.AddMessage(MessageType.Exception, "An error occurred while adding the admin");
       }

       return result;
    }

    public ResultObject<bool> UpdateAdmin(AdminDTO adminDTO)
    {
       ResultObject<bool> result = new ResultObject<bool>();
         if(adminDTO == null)
         {
          result.Succeeded = false;
          result.AddMessage(MessageType.LogicalError, "No admin data found");
         }

         try
         {
             
             AdminDTO adminDto = _baseRepository.Get<AdminDTO>(adminDTO.AdminID);
             if (adminDto != null)
             {
                 adminDto.AdminID = adminDTO.AdminID;
                 adminDto.FirstName = adminDTO.FirstName;
                 adminDto.LastName = adminDTO.LastName;
                 adminDto.Email = adminDTO.Email;
                 adminDto.PhoneNumber = adminDTO.PhoneNumber;
                 adminDto.AccountID = adminDTO.AccountID;
                 adminDto.PracticeID = adminDTO.PracticeID;
                 adminDto.InventoryID = adminDTO.InventoryID;

                 _baseRepository.Update<AdminDTO>(adminDto,adminDTO.AdminID);
                 _unitOfWork.Commit();
                 result.Succeeded = true;
                 result.Result = true;
             }
             else
             {
                 result.Succeeded = false;
                 result.AddMessage(MessageType.LogicalError, "No admin data found");
             }
         }
         catch (Exception e)
         {
             result.Succeeded = false;
                result.AddMessage(MessageType.Exception, "An error occurred while updating the admin");
         }

         return result;
    }

    public ResultObject<bool> DeleteAdmin(int adminID)
    {
        ResultObject<bool> result = new ResultObject<bool>();
        try
        {
            AdminDTO admin = _baseRepository.Get<AdminDTO>(adminID);
            if (admin != null)
            {
                _baseRepository.Delete<AdminDTO>(admin);
                _unitOfWork.Commit();
                result.Succeeded = true;
                result.Result = true;
            }
            else
            {
                result.Succeeded = false;
                result.AddMessage(MessageType.LogicalError, "No admin data found");
            }
        }
        catch (Exception e)
        {
            result.Succeeded = false;
            result.AddMessage(MessageType.Exception, "An error occurred while deleting the admin");
        }

        return result;
    }

    public ResultObject<bool> GetAdmin(int adminID)
    {
        ResultObject<bool> result = new ResultObject<bool>();
        try
        {
            AdminDTO admin = _baseRepository.Get<AdminDTO>(adminID);
            if (admin != null)
            {
                result.Succeeded = true;
                result.Result = true;
            }
            else
            {
                result.Succeeded = false;
                result.AddMessage(MessageType.LogicalError, "No admin data found");
            }
        }
        catch (Exception e)
        {
            result.Succeeded = false;
            result.AddMessage(MessageType.Exception, "An error occurred while getting the admin");
        }

        return result;
    }

    public ResultObject<ICollection<AdminDTO>> GetAllAdmins()
    {
        ResultObject<ICollection<AdminDTO>> result = new ResultObject<ICollection<AdminDTO>>();
        try
        {
            ICollection<AdminDTO> admins = _baseRepository.GetAll<AdminDTO>();
            if (admins != null)
            {
                result.Succeeded = true;
                result.Result = admins;
            }
            else
            {
                result.Succeeded = false;
                result.AddMessage(MessageType.LogicalError, "No admin data found");
            }
        }
        catch (Exception e)
        {
            result.Succeeded = false;
            result.AddMessage(MessageType.Exception, "An error occurred while getting the admin");
        }

        return result;
    }
}