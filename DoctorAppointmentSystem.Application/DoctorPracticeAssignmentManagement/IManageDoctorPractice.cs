using DoctorAppointmentSystem.Application.DTOs;

namespace DoctorAppointmentSystem.Application.DoctorPracticeAssignmentManagement;

public interface IManageDoctorPractice
{
    ResultObject<DoctorPracticeAssignmentDTO> GetDoctorPracticeAssignment(int doctorPracticeAssignmentID);
    
    ResultObject<ICollection<DoctorPracticeAssignmentDTO>> GetAllDoctorPracticeAssignments();
    
    ResultObject<bool> AddDoctorPracticeAssignment(DoctorPracticeAssignmentDTO doctorPracticeAssignmentDTO);
    
    ResultObject<bool> UpdateDoctorPracticeAssignment(DoctorPracticeAssignmentDTO doctorPracticeAssignmentDTO);
    
    ResultObject<bool> DeleteDoctorPracticeAssignment(int doctorPracticeAssignmentID);
    
    
}