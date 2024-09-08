using DoctorAppointmentSystem.Application.DTOs;
using DoctorAppointmentSystem.Core.UOW;

namespace DoctorAppointmentSystem.Application.DoctorPracticeManagement;

public class ManageDoctorPractice: IManageDoctorPractice
{
    private readonly IUnitOfWork _unitOfWork;
    
    private readonly IBaseRepository _baseRepository;
    
    public ManageDoctorPractice(IUnitOfWork unitOfWork, IBaseRepository baseRepository)
    {
        _unitOfWork = unitOfWork;
        _baseRepository = baseRepository;
    }


    public ResultObject<DoctorPracticeDTO> GetDoctorPractice(int practiceID)
    {
        ResultObject<DoctorPracticeDTO> result = new ResultObject<DoctorPracticeDTO>();

        try
        {
            DoctorPracticeDTO doctorPracticeDTO = _baseRepository.Get<DoctorPracticeDTO>(practiceID);

            if (doctorPracticeDTO != null)
            {
                DoctorPracticeDTO doctorPracticeResult = new DoctorPracticeDTO
                {
                    Name = doctorPracticeDTO.Name,
                    Address = doctorPracticeDTO.Address,
                    PhoneNumber = doctorPracticeDTO.PhoneNumber,
                    City = doctorPracticeDTO.City,
                    Area = doctorPracticeDTO.Area,
                    PostalCode = doctorPracticeDTO.PostalCode,
                    AdminID = doctorPracticeDTO.AdminID
                };

                result.Result = doctorPracticeResult;
                result.Succeeded = true;
            }
            else
            {
                result.Succeeded = false;
                result.AddMessage(MessageType.LogicalError, "Doctor practice not found.");
            }
        }
        catch (Exception ex)
        {
            result.Succeeded = false;
            result.AddMessage(MessageType.Exception, $"An error occurred while retrieving the doctor practice: {ex.Message}");
        }

        return result;
    }

    public ResultObject<ICollection<DoctorPracticeDTO>> GetAllDoctorPractices()
    {
        ResultObject<ICollection<DoctorPracticeDTO>> result = new ResultObject<ICollection<DoctorPracticeDTO>>();

        try
        {
            ICollection<DoctorPracticeDTO> doctorPracticeDTOs = _baseRepository.GetAll<DoctorPracticeDTO>();
            result.Result = doctorPracticeDTOs;
            result.Succeeded = true;
        }
        catch (Exception ex)
        {
            result.Succeeded = false;
            result.AddMessage(MessageType.Exception, $"An error occurred while retrieving the doctor practices: {ex.Message}");
        }

        return result;
    }

    public ResultObject<bool> AddDoctorPractice(DoctorPracticeDTO doctorPracticeDTO)
    {
        ResultObject<bool> result = new ResultObject<bool>();

        if (doctorPracticeDTO == null)
        {
            result.Succeeded = false;
            result.AddMessage(MessageType.LogicalError, "Doctor practice data is required.");
            return result;
        }

        try
        {
            Core.Entities.DoctorPractice doctorPracticeEntity = new Core.Entities.DoctorPractice
            {
                Name = doctorPracticeDTO.Name,
                Address = doctorPracticeDTO.Address,
                PhoneNumber = doctorPracticeDTO.PhoneNumber,
                City = doctorPracticeDTO.City,
                Area = doctorPracticeDTO.Area,
                PostalCode = doctorPracticeDTO.PostalCode,
                AdminID = doctorPracticeDTO.AdminID??0
            };

            _baseRepository.Add<Core.Entities.DoctorPractice>(doctorPracticeEntity);
            _unitOfWork.Commit();

            result.Succeeded = true;
        }
        catch (Exception ex)
        {
            result.Succeeded = false;
            result.AddMessage(MessageType.Exception, $"An error occurred while adding the doctor practice: {ex.Message}");
        }

        return result;
    }

    public ResultObject<bool> UpdateDoctorPractice(DoctorPracticeDTO doctorPracticeDTO)
    {
        ResultObject<bool> result = new ResultObject<bool>();

        if (doctorPracticeDTO == null)
        {
            result.Succeeded = false;
            result.AddMessage(MessageType.LogicalError, "No doctor practice data found.");
            return result;
        }

        try
        {
            Core.Entities.DoctorPractice doctorPracticeEntity = _baseRepository.Get<Core.Entities.DoctorPractice>(doctorPracticeDTO.PracticeID);

            if (doctorPracticeEntity != null)
            {
                doctorPracticeEntity.Name = doctorPracticeDTO.Name;
                doctorPracticeEntity.Address = doctorPracticeDTO.Address;
                doctorPracticeEntity.PhoneNumber = doctorPracticeDTO.PhoneNumber;
                doctorPracticeEntity.City = doctorPracticeDTO.City;
                doctorPracticeEntity.Area = doctorPracticeDTO.Area;
                doctorPracticeEntity.PostalCode = doctorPracticeDTO.PostalCode;
                doctorPracticeEntity.AdminID = doctorPracticeDTO.AdminID ?? 0;

                _baseRepository.Update<Core.Entities.DoctorPractice>(doctorPracticeEntity,doctorPracticeEntity.PracticeID);
                _unitOfWork.Commit();

                result.Succeeded = true;
            }
            else
            {
                result.Succeeded = false;
                result.AddMessage(MessageType.LogicalError, "Doctor practice not found.");
            }
        }
        catch (Exception ex)
        {
            result.Succeeded = false;
            result.AddMessage(MessageType.Exception, $"An error occurred while updating the doctor practice: {ex.Message}");
        }

        return result;
    }

    public ResultObject<bool> DeleteDoctorPractice(int practiceID)
    {
        ResultObject<bool> result = new ResultObject<bool>();

        try
        {
            Core.Entities.DoctorPractice doctorPracticeEntity = _baseRepository.Get<Core.Entities.DoctorPractice>(practiceID);

            if (doctorPracticeEntity != null)
            {
                _baseRepository.Delete<Core.Entities.DoctorPractice>(doctorPracticeEntity);
                _unitOfWork.Commit();

                result.Succeeded = true;
            }
            else
            {
                result.Succeeded = false;
                result.AddMessage(MessageType.LogicalError, "Doctor practice not found.");
            }
        }
        catch (Exception ex)
        {
            result.Succeeded = false;
            result.AddMessage(MessageType.Exception, $"An error occurred while deleting the doctor practice: {ex.Message}");
        }

        return result;
    }
}