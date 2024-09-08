using DoctorAppointmentSystem.Application.DTOs;

namespace DoctorAppointmentSystem.Application.AccountDetails;

public interface IManageAccountDetails
{
    ResultObject<AccountDetailsDTO> GetAccountDetails(int accountID);
    
    ResultObject<ICollection<AccountDetailsDTO>> GetAllAccountDetails();
    
    ResultObject<bool> AddAccountDetails(AccountDetailsDTO accountDetailsDTO);
    
    ResultObject<bool> UpdateAccountDetails(AccountDetailsDTO accountDetailsDTO);
    
    ResultObject<bool> DeleteAccountDetails(int accountID);
    
}