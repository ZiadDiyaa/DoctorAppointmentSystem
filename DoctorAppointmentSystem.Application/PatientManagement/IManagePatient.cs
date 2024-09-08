using DoctorAppointmentSystem.Application.DTOs;
using DoctorAppointmentSystem.Core.Entities;

namespace DoctorAppointmentSystem.Application.PatientManagement;

public interface IManagePatient
{
    ResultObject<PatientDTO> GetPatient(int patientID);
    
    ResultObject<ICollection<PatientDTO>> GetAllPatients();
    
    ResultObject<bool> AddPatient(PatientDTO patientDTO);
    
    ResultObject<bool> UpdatePatient(PatientDTO patientDTO);
    
    ResultObject<bool> DeletePatient(int patientID);
    
    
}