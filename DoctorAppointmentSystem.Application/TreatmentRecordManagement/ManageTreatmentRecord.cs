using DoctorAppointmentSystem.Application.DTOs;
using DoctorAppointmentSystem.Core.Entities;
using DoctorAppointmentSystem.Core.UOW;

namespace DoctorAppointmentSystem.Application.TreatmentRecordManagement;

public class ManageTreatmentRecord: IManageTreatmentRecord
{

    private readonly IUnitOfWork _unitOfWork;

    private readonly IBaseRepository _baseRepository;

    public ManageTreatmentRecord(IUnitOfWork unitOfWork, IBaseRepository baseRepository)
    {
        _unitOfWork = unitOfWork;
        _baseRepository = baseRepository;
    }
     public ResultObject<TreatmentRecordDTO> GetTreatmentRecord(int treatmentRecordID)
    {
        ResultObject<TreatmentRecordDTO> result = new ResultObject<TreatmentRecordDTO>();
        try
        {
            var treatmentRecord = _baseRepository.Get<TreatmentRecord>(treatmentRecordID);

            if (treatmentRecord != null)
            {
                TreatmentRecordDTO treatmentRecordDTO = new TreatmentRecordDTO
                {
                    TreatmentRecordID = treatmentRecord.TreatmentRecordID,
                    PatientID = treatmentRecord.PatientID,
                    DoctorID = treatmentRecord.DoctorID,
                    TreatmentDate = treatmentRecord.TreatmentDate,
                    TreatmentType = treatmentRecord.TreatmentType,
                    TreatmentDetails = treatmentRecord.TreatmentDetails
                };

                result.Succeeded = true;
                result.Result = treatmentRecordDTO;
            }
            else
            {
                result.Succeeded = false;
                result.AddMessage(MessageType.LogicalError, "Treatment record not found.");
            }
        }
        catch (Exception e)
        {
            result.Succeeded = false;
            result.AddMessage(MessageType.Exception, $"An error occurred while retrieving the treatment record: {e.Message}");
        }

        return result;
    }

    public ResultObject<ICollection<TreatmentRecordDTO>> GetAllTreatmentRecords()
    {
        ResultObject<ICollection<TreatmentRecordDTO>> result = new ResultObject<ICollection<TreatmentRecordDTO>>();
        try
        {
            var treatmentRecords = _baseRepository.GetAll<TreatmentRecord>();

            if (treatmentRecords != null && treatmentRecords.Any())
            {
                List<TreatmentRecordDTO> treatmentRecordDTOs = treatmentRecords.Select(treatmentRecord => new TreatmentRecordDTO
                {
                    TreatmentRecordID = treatmentRecord.TreatmentRecordID,
                    PatientID = treatmentRecord.PatientID,
                    DoctorID = treatmentRecord.DoctorID,
                    TreatmentDate = treatmentRecord.TreatmentDate,
                    TreatmentType = treatmentRecord.TreatmentType,
                    TreatmentDetails = treatmentRecord.TreatmentDetails
                }).ToList();

                result.Succeeded = true;
                result.Result = treatmentRecordDTOs;
            }
            else
            {
                result.Succeeded = false;
                result.AddMessage(MessageType.LogicalError, "No treatment records found.");
            }
        }
        catch (Exception e)
        {
            result.Succeeded = false;
            result.AddMessage(MessageType.Exception, $"An error occurred while retrieving the treatment records: {e.Message}");
        }

        return result;
    }

    public ResultObject<bool> AddTreatmentRecord(TreatmentRecordDTO treatmentRecordDTO)
    {
        ResultObject<bool> result = new ResultObject<bool>();
        try
        {
            var treatmentRecord = new TreatmentRecord
            {
                PatientID = treatmentRecordDTO.PatientID,
                DoctorID = treatmentRecordDTO.DoctorID,
                TreatmentDate = treatmentRecordDTO.TreatmentDate,
                TreatmentType = treatmentRecordDTO.TreatmentType,
                TreatmentDetails = treatmentRecordDTO.TreatmentDetails
            };

            _baseRepository.Add(treatmentRecord);
_unitOfWork.Commit();
            result.Succeeded = true;
            result.Result = true;
        }
        catch (Exception e)
        {
            result.Succeeded = false;
            result.AddMessage(MessageType.Exception, $"An error occurred while adding the treatment record: {e.Message}");
        }

        return result;
    }

    public ResultObject<bool> UpdateTreatmentRecord(TreatmentRecordDTO treatmentRecordDTO)
    {
        ResultObject<bool> result = new ResultObject<bool>();
        try
        {
            var treatmentRecord = _baseRepository.Get<TreatmentRecord>(treatmentRecordDTO.TreatmentRecordID);

            if (treatmentRecord != null)
            {
                treatmentRecord.PatientID = treatmentRecordDTO.PatientID;
                treatmentRecord.DoctorID = treatmentRecordDTO.DoctorID;
                treatmentRecord.TreatmentDate = treatmentRecordDTO.TreatmentDate;
                treatmentRecord.TreatmentType = treatmentRecordDTO.TreatmentType;
                treatmentRecord.TreatmentDetails = treatmentRecordDTO.TreatmentDetails;

                _baseRepository.Update(treatmentRecord,treatmentRecordDTO.TreatmentRecordID);
                _unitOfWork.Commit();

                result.Succeeded = true;
                result.Result = true;
            }
            else
            {
                result.Succeeded = false;
                result.AddMessage(MessageType.LogicalError, "Treatment record not found.");
            }
        }
        catch (Exception e)
        {
            result.Succeeded = false;
            result.AddMessage(MessageType.Exception, $"An error occurred while updating the treatment record: {e.Message}");
        }

        return result;
    }

  

    public ResultObject<bool> DeleteTreatmentRecord(int treatmentRecordID)
    {
        ResultObject<bool> result = new ResultObject<bool>();
        try
        {
            var treatmentRecord = _baseRepository.Get<TreatmentRecord>(treatmentRecordID);

            if (treatmentRecord != null)
            {
                _baseRepository.Delete(treatmentRecord);
                _unitOfWork.Commit();

                result.Succeeded = true;
                result.Result = true;
            }
            else
            {
                result.Succeeded = false;
                result.AddMessage(MessageType.LogicalError, "Treatment record not found.");
            }
        }
        catch (Exception e)
        {
            result.Succeeded = false;
            result.AddMessage(MessageType.Exception, $"An error occurred while deleting the treatment record: {e.Message}");
        }

        return result;
    }
}