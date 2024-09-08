using DoctorAppointmentSystem.Application.DTOs;
using DoctorAppointmentSystem.Core.UOW;

namespace DoctorAppointmentSystem.Application.AccountDetails;

public class ManageAccountDetails: IManageAccountDetails
{

    private readonly IBaseRepository baseRepository;

    private readonly IUnitOfWork _unitOfWork;
    public ManageAccountDetails(IBaseRepository baseRepository, IUnitOfWork unit)
    {
        this.baseRepository = baseRepository;
        _unitOfWork=unit;
    }
    public ResultObject<AccountDetailsDTO> GetAccountDetails(int accountID)
    {
        ResultObject<AccountDetailsDTO> result = new ResultObject<AccountDetailsDTO>();

        try
        {
            Core.Entities.AccountDetails accountDetailsEntity = baseRepository.Get<Core.Entities.AccountDetails>(accountID);

            if (accountDetailsEntity != null)
            {
                AccountDetailsDTO accountDTO = new AccountDetailsDTO
                {
                    UserName = accountDetailsEntity.Username,
                    PasswordHash = accountDetailsEntity.PasswordHash,
                    Email = accountDetailsEntity.Email,
                    CreatedDate = accountDetailsEntity.CreatedDate,
                    LastLoginDate = accountDetailsEntity.LastLoginDate
                };

                result.Result = accountDTO;
                result.Succeeded = true;
            }
            else
            {
                result.Succeeded = false;
                result.AddMessage(MessageType.LogicalError, "Account details not found.");
            }
        }
        catch (Exception ex)
        {
            result.Succeeded = false;
            result.AddMessage(MessageType.Exception, $"An error occurred while retrieving the account details: {ex.Message}");
        }

        return result;
    }
   
        


    public ResultObject<ICollection<AccountDetailsDTO>> GetAllAccountDetails()
    {
        ResultObject<ICollection<AccountDetailsDTO>> result = new ResultObject<ICollection<AccountDetailsDTO>>();

        try
        {
            ICollection<Core.Entities.AccountDetails> accountDetailsEntities = baseRepository.GetAll<Core.Entities.AccountDetails>();

            if (accountDetailsEntities != null)
            {
                ICollection<AccountDetailsDTO> accountDTOs = new List<AccountDetailsDTO>();

                foreach (Core.Entities.AccountDetails accountDetailsEntity in accountDetailsEntities)
                {
                    AccountDetailsDTO accountDTO = new AccountDetailsDTO
                    {
                        UserName = accountDetailsEntity.Username,
                        PasswordHash = accountDetailsEntity.PasswordHash,
                        Email = accountDetailsEntity.Email,
                        CreatedDate = accountDetailsEntity.CreatedDate,
                        LastLoginDate = accountDetailsEntity.LastLoginDate
                    };

                    accountDTOs.Add(accountDTO);
                }

                result.Result = accountDTOs;
                result.Succeeded = true;
            }
            else
            {
                result.Succeeded = false;
                result.AddMessage(MessageType.LogicalError, "No account details found.");
            }
        }
        catch (Exception ex)
        {
            result.Succeeded = false;
            result.AddMessage(MessageType.Exception, $"An error occurred while retrieving the account details: {ex.Message}");
        }

        return result;
    }

  
    public ResultObject<bool> AddAccountDetails(AccountDetailsDTO accountDetailsDTO)
    {
        ResultObject<bool> result = new ResultObject<bool>();

        try
        {
            Core.Entities.AccountDetails accountDetailsEntity = new Core.Entities.AccountDetails
            {
                Username = accountDetailsDTO.UserName,
                PasswordHash = accountDetailsDTO.PasswordHash,
                Email = accountDetailsDTO.Email,
                CreatedDate = accountDetailsDTO.CreatedDate,
                LastLoginDate = accountDetailsDTO.LastLoginDate
            };

            baseRepository.Add(accountDetailsEntity);
            _unitOfWork.Commit();

            result.Result = true;
            result.Succeeded = true;
        }
        catch (Exception ex)
        {
            result.Succeeded = false;
            result.AddMessage(MessageType.Exception, $"An error occurred while adding the account details: {ex.Message}");
        }

        return result;
    }

    public ResultObject<bool> UpdateAccountDetails(AccountDetailsDTO accountDetailsDTO)
    {
        ResultObject<bool> result = new ResultObject<bool>();

        try
        {
            Core.Entities.AccountDetails accountDetailsEntity = baseRepository.Get<Core.Entities.AccountDetails>(accountDetailsDTO.AccountID);

            if (accountDetailsEntity != null)
            {
                accountDetailsEntity.Username = accountDetailsDTO.UserName;
                accountDetailsEntity.PasswordHash = accountDetailsDTO.PasswordHash;
                accountDetailsEntity.Email = accountDetailsDTO.Email;
                accountDetailsEntity.CreatedDate = accountDetailsDTO.CreatedDate;
                accountDetailsEntity.LastLoginDate = accountDetailsDTO.LastLoginDate;

                _unitOfWork.Commit();

                result.Result = true;
                result.Succeeded = true;
            }
            else
            {
                result.Succeeded = false;
                result.AddMessage(MessageType.LogicalError, "Account details not found.");
            }
        }
        catch (Exception ex)
        {
            result.Succeeded = false;
            result.AddMessage(MessageType.Exception, $"An error occurred while updating the account details: {ex.Message}");
        }

        return result;
    }

    public ResultObject<bool> DeleteAccountDetails(int accountID)
    {
        ResultObject<bool> result = new ResultObject<bool>();

        try
        { 
            Core.Entities.AccountDetails accountDetailsEntity = baseRepository.Get<Core.Entities.AccountDetails>(accountID);

            if (accountDetailsEntity != null)
            {
                baseRepository.Delete(accountDetailsEntity);
                _unitOfWork.Commit();

                result.Result = true;
                result.Succeeded = true;
            }
            else
            {
                result.Succeeded = false;
                result.AddMessage(MessageType.LogicalError, "Account details not found.");
            }
        }
        catch (Exception ex)
        {
            result.Succeeded = false;
            result.AddMessage(MessageType.Exception, $"An error occurred while deleting the account details: {ex.Message}");
        }

        return result;
    }
}