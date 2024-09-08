using DoctorAppointmentSystem.Application.DTOs;
using DoctorAppointmentSystem.Core.Entities;
using DoctorAppointmentSystem.Core.UOW;

namespace DoctorAppointmentSystem.Application.PatientManagement;

public class ManagePatient : IManagePatient
{
    private readonly IUnitOfWork _unitOfWork;

    private readonly IBaseRepository _baseRepository;

    public ManagePatient(IUnitOfWork unitOfWork, IBaseRepository baseRepository)
    {
        _unitOfWork = unitOfWork;
        _baseRepository = baseRepository;
    }


    public ResultObject<PatientDTO> GetPatient(int patientID)
    {
        ResultObject<PatientDTO> result = new ResultObject<PatientDTO>();

        try
        {
           

            var patient = _baseRepository.Find<Patient>(x => x.PatientID == patientID);

            if (patient != null)
            {
                PatientDTO patientResult = new PatientDTO
                {
                    PatientID = patient.PatientID,
                    FirstName = patient.FirstName,
                    LastName = patient.LastName,
                    DateOfBirth = patient.DateOfBirth,
                    Email = patient.Email,
                    PhoneNumber = patient.PhoneNumber,
                    Address = patient.Address,
                    MedicalHistory = patient.MedicalHistory,
                    AccountID = patient.AccountID,

                };
                
                foreach(Appointment appointments in patient.Appointments)
                {
                    AppointmentDTO appointmentDTO = new AppointmentDTO
                    {
                        AppointmentID = appointments.AppointmentID,
                        DoctorID = appointments.DoctorID,
                        PatientID = appointments.PatientID,
                        AppointmentDate = appointments.AppointmentDate,
                        StartTime = appointments.StartTime,
                        Status = appointments.Status
                    };
                    patientResult.Appointments.Add(appointmentDTO);
                }

                result.Succeeded = true;
                result.Result = patientResult;
            }
            else
            {
                result.Succeeded = false;
                result.AddMessage(MessageType.LogicalError, "Patient not found.");
            }
        }
        catch (Exception e)
        {
            result.Succeeded = false;
            result.AddMessage(MessageType.Exception, $"An error occurred while retrieving the patient: {e.Message}");
        }

        return result;
    }


   public ResultObject<ICollection<PatientDTO>> GetAllPatients()
{
    ResultObject<ICollection<PatientDTO>> result = new ResultObject<ICollection<PatientDTO>>();

    try
    {
        var patients = _baseRepository.GetAll<Patient>().ToList();

        if (patients != null && patients.Any())
        {
            List<PatientDTO> patientDTOs = new List<PatientDTO>();

            foreach (var patient in patients)
            {
                PatientDTO patientResult = new PatientDTO
                {
                    PatientID = patient.PatientID,
                    FirstName = patient.FirstName,
                    LastName = patient.LastName,
                    DateOfBirth = patient.DateOfBirth,
                    Email = patient.Email,
                    PhoneNumber = patient.PhoneNumber,
                    Address = patient.Address,
                    MedicalHistory = patient.MedicalHistory,
                    AccountID = patient.AccountID,
                    Appointments = new List<AppointmentDTO>()
                };

                foreach (var appointment in patient.Appointments)
                {
                    AppointmentDTO appointmentDTO = new AppointmentDTO
                    {
                        AppointmentID = appointment.AppointmentID,
                        DoctorID = appointment.DoctorID,
                        PatientID = appointment.PatientID,
                        AppointmentDate = appointment.AppointmentDate,
                        StartTime = appointment.StartTime,
                        Status = appointment.Status
                    };
                    patientResult.Appointments.Add(appointmentDTO);
                }

                patientDTOs.Add(patientResult);
            }

            result.Succeeded = true;
            result.Result = patientDTOs;
        }
        else
        {
            result.Succeeded = false;
            result.AddMessage(MessageType.LogicalError, "No patients found.");
        }
    }
    catch (Exception e)
    {
        result.Succeeded = false;
        result.AddMessage(MessageType.Exception, $"An error occurred while retrieving the patients: {e.Message}");
    }

    return result;
}

    public ResultObject<bool> AddPatient(PatientDTO patientDTO)
    {
        ResultObject<bool> result = new ResultObject<bool>();

        try
        {
            Patient patientEntity = new Patient
            {
                FirstName = patientDTO.FirstName,
                LastName = patientDTO.LastName,
                DateOfBirth = patientDTO.DateOfBirth,
                Email = patientDTO.Email,
                PhoneNumber = patientDTO.PhoneNumber,
                Address = patientDTO.Address,
                MedicalHistory = patientDTO.MedicalHistory,
                AccountID = patientDTO.AccountID
            };

            _baseRepository.Add(patientEntity);
            _unitOfWork.Commit();

            result.Result = true;
            result.Succeeded = true;
        }
        catch (Exception e)
        {
            result.Succeeded = false;
            result.AddMessage(MessageType.Exception, $"An error occurred while adding the patient: {e.Message}");
        }

        return result;
    }

    public ResultObject<bool> UpdatePatient(PatientDTO patientDTO)
    {
        ResultObject<bool> result = new ResultObject<bool>();

        try
        {
            Patient patientEntity = _baseRepository.Find<Patient>(x => x.PatientID == patientDTO.PatientID);

            if (patientEntity != null)
            {
                patientEntity.FirstName = patientDTO.FirstName;
                patientEntity.LastName = patientDTO.LastName;
                patientEntity.DateOfBirth = patientDTO.DateOfBirth;
                patientEntity.Email = patientDTO.Email;
                patientEntity.PhoneNumber = patientDTO.PhoneNumber;
                patientEntity.Address = patientDTO.Address;
                patientEntity.MedicalHistory = patientDTO.MedicalHistory;
                patientEntity.AccountID = patientDTO.AccountID;

                _baseRepository.Update(patientEntity, patientEntity.PatientID);
                _unitOfWork.Commit();

                result.Result = true;
                result.Succeeded = true;
            }
            else
            {
                result.Succeeded = false;
                result.AddMessage(MessageType.LogicalError, "Patient not found.");
            }
        }
        catch (Exception e)
        {
            result.Succeeded = false;
            result.AddMessage(MessageType.Exception, $"An error occurred while updating the patient: {e.Message}");
        }

        return result;
    }

    public ResultObject<bool> DeletePatient(int patientID)
    {
        ResultObject<bool> result = new ResultObject<bool>();
        Patient customer= _baseRepository.Get<Patient>(patientID);
        
        if(customer==null)
        {
            result.Succeeded=false;
            result.AddMessage(MessageType.LogicalError, "Patient not found.");
        }
        else
        {
            _baseRepository.Delete(customer);
            _unitOfWork.Commit();
            result.Result=true;
            result.Succeeded=true;
        }
        return result;
    }
}