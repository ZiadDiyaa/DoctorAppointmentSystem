using DoctorAppointmentSystem.Application.DoctorMangement;
using DoctorAppointmentSystem.Application.DTOs;
using DoctorAppointmentSystem.Core.UOW;

namespace DoctorAppointmentSystem.Application.DoctorPracticeAssignmentManagement;

public class ManageDoctorPractice: IManageDoctorPractice
{
    private readonly IUnitOfWork _unitOfWork;
    
    private readonly IBaseRepository _baseRepository;
    
    public ManageDoctorPractice(IUnitOfWork unit, IBaseRepository baseRepository)
    {
        _unitOfWork=unit;
        _baseRepository=baseRepository;
    }


    public ResultObject<DoctorPracticeAssignmentDTO> GetDoctorPracticeAssignment(int doctorPracticeAssignmentID)
    {
        ResultObject<DoctorPracticeAssignmentDTO> result = new ResultObject<DoctorPracticeAssignmentDTO>();
        
        try
        {
            Core.Entities.DoctorPracticeAssignment doctorPracticeAssignmentEntity = _baseRepository.Get<Core.Entities.DoctorPracticeAssignment>(doctorPracticeAssignmentID);
            
            if(doctorPracticeAssignmentEntity != null)
            {
                DoctorPracticeAssignmentDTO doctorPracticeAssignmentDTO = new DoctorPracticeAssignmentDTO
                {
                    DoctorID = doctorPracticeAssignmentEntity.DoctorID,
                    PracticeID = doctorPracticeAssignmentEntity.PracticeID,
                };
                
                result.Result = doctorPracticeAssignmentDTO;
                result.Succeeded = true;
            }
            else
            {
                result.Succeeded = false;
                result.AddMessage(MessageType.LogicalError, "Doctor practice assignment not found.");
            }
        }
        catch(Exception ex)
        {
            result.Succeeded = false;
            result.AddMessage(MessageType.Exception, $"An error occurred while retrieving the doctor practice assignment: {ex.Message}");
        }

        return result;
    }

    public ResultObject<ICollection<DoctorPracticeAssignmentDTO>> GetAllDoctorPracticeAssignments()
    {
        ResultObject<ICollection<DoctorPracticeAssignmentDTO>> result = new ResultObject<ICollection<DoctorPracticeAssignmentDTO>>();
        
        try
        {
            ICollection<DoctorPracticeAssignmentDTO> doctorPracticeAssignmentDTOs = _baseRepository.GetAll<DoctorPracticeAssignmentDTO>();
            
            if(doctorPracticeAssignmentDTOs != null)
            {
                result.Result = doctorPracticeAssignmentDTOs;
                result.Succeeded = true;
            }
            else
            {
                result.Succeeded = false;
                result.AddMessage(MessageType.LogicalError, "Doctor practice assignments not found.");
            }
        }
        catch(Exception ex)
        {
            result.Succeeded = false;
            result.AddMessage(MessageType.Exception, $"An error occurred while retrieving the doctor practice assignments: {ex.Message}");
        }

        return result;
    }

    public ResultObject<bool> AddDoctorPracticeAssignment(DoctorPracticeAssignmentDTO doctorPracticeAssignmentDTO)
    {
        ResultObject<bool> result = new ResultObject<bool>();
        
        if(doctorPracticeAssignmentDTO == null)
        {
            result.Succeeded = false;
            result.AddMessage(MessageType.LogicalError, "No doctor practice assignment data found");
        }
        else
        {
            try
            {
                Core.Entities.DoctorPracticeAssignment doctorPracticeAssignmentEntity = new Core.Entities.DoctorPracticeAssignment
                {
                    DoctorID = doctorPracticeAssignmentDTO.DoctorID,
                    PracticeID = doctorPracticeAssignmentDTO.PracticeID,
                };
                
                _baseRepository.Add<Core.Entities.DoctorPracticeAssignment>(doctorPracticeAssignmentEntity);
                _unitOfWork.Commit();
                
                result.Result = true;
                result.Succeeded = true;
            }
            catch(Exception ex)
            {
                result.Succeeded = false;
                result.AddMessage(MessageType.Exception, $"An error occurred while adding the doctor practice assignment: {ex.Message}");
            }
        }

        return result;
    }

    public ResultObject<bool> UpdateDoctorPracticeAssignment(DoctorPracticeAssignmentDTO doctorPracticeAssignmentDTO)
    {
        ResultObject<bool> result = new ResultObject<bool>();
        
        if(doctorPracticeAssignmentDTO == null)
        {
            result.Succeeded = false;
            result.AddMessage(MessageType.LogicalError, "No doctor practice assignment data found");
        }
        else
        {
            try
            {
                Core.Entities.DoctorPracticeAssignment doctorPracticeAssignmentEntity = _baseRepository.Get<Core.Entities.DoctorPracticeAssignment>(doctorPracticeAssignmentDTO.DoctorID);
                
                if(doctorPracticeAssignmentEntity != null)
                {
                    doctorPracticeAssignmentEntity.DoctorID = doctorPracticeAssignmentDTO.DoctorID;
                    doctorPracticeAssignmentEntity.PracticeID = doctorPracticeAssignmentDTO.PracticeID;
                    
                    _baseRepository.Update<Core.Entities.DoctorPracticeAssignment>(doctorPracticeAssignmentEntity, doctorPracticeAssignmentEntity.DoctorID);
                    _unitOfWork.Commit();
                    
                    result.Result = true;
                    result.Succeeded = true;
                }
                else
                {
                    result.Succeeded = false;
                    result.AddMessage(MessageType.LogicalError, "Doctor practice assignment not found.");
                }
            }
            catch(Exception ex)
            {
                result.Succeeded = false;
                result.AddMessage(MessageType.Exception, $"An error occurred while updating the doctor practice assignment: {ex.Message}");
            }
        }

        return result;
    }

    public ResultObject<bool> DeleteDoctorPracticeAssignment(int doctorPracticeAssignmentID)
    {
        ResultObject<bool> result = new ResultObject<bool>();
        
        try
        {
            Core.Entities.DoctorPracticeAssignment doctorPracticeAssignmentEntity = _baseRepository.Get<Core.Entities.DoctorPracticeAssignment>(doctorPracticeAssignmentID);
            
            if(doctorPracticeAssignmentEntity != null)
            {
                _baseRepository.Delete<Core.Entities.DoctorPracticeAssignment>(doctorPracticeAssignmentEntity);
                _unitOfWork.Commit();
                
                result.Result = true;
                result.Succeeded = true;
            }
            else
            {
                result.Succeeded = false;
                result.AddMessage(MessageType.LogicalError, "Doctor practice assignment not found.");
            }
        }
        catch(Exception ex)
        {
            result.Succeeded = false;
            result.AddMessage(MessageType.Exception, $"An error occurred while deleting the doctor practice assignment: {ex.Message}");
        }

        return result;
    }
}