using DoctorAppointmentSystem.Application.DTOs;

namespace DoctorAppointmentSystem.Application.TreatmentRecordManagement;

public interface IManageTreatmentRecord
{
    ResultObject<TreatmentRecordDTO> GetTreatmentRecord(int treatmentRecordID);
    
    ResultObject<ICollection<TreatmentRecordDTO>> GetAllTreatmentRecords();
    
    ResultObject<bool> AddTreatmentRecord(TreatmentRecordDTO treatmentRecordDTO);
    
    ResultObject<bool> UpdateTreatmentRecord(TreatmentRecordDTO treatmentRecordDTO);
    
    ResultObject<bool> DeleteTreatmentRecord(int treatmentRecordDTO);
}