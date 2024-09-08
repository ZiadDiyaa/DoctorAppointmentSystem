using DoctorAppointmentSystem.Application.DTOs;
using DoctorAppointmentSystem.Core.UOW;

namespace DoctorAppointmentSystem.Application.AppointmentManagement;

public class ManageAppointment: IManageAppointment
{

    private readonly IUnitOfWork unitOfWork;

    private readonly IBaseRepository baseRepository;
    
    public ManageAppointment(IUnitOfWork unitOfWork, IBaseRepository baseRepository)
    {
        this.unitOfWork = unitOfWork;
        this.baseRepository = baseRepository;
        
    }
    public ResultObject<AppointmentDTO> GetAppointment(int appointmentID)
    {
        ResultObject<AppointmentDTO> result = new ResultObject<AppointmentDTO>();
        
        try
        {
            Core.Entities.Appointment appointmentEntity = baseRepository.Get<Core.Entities.Appointment>(appointmentID);
            
            if (appointmentEntity != null)
            {
                AppointmentDTO appointmentDTO = new AppointmentDTO
                {
                    AppointmentID = appointmentEntity.AppointmentID,
                    DoctorID = appointmentEntity.DoctorID,
                    PatientID = appointmentEntity.PatientID,
                    AppointmentDate = appointmentEntity.AppointmentDate,
                    StartTime = appointmentEntity.StartTime,
                    // EndTime = appointmentEntity.EndTime,
                    // TreatmentType = appointmentEntity.TreatmentType,
                    Status = appointmentEntity.Status
                    
                };
                
                result.Result = appointmentDTO;
                result.Succeeded = true;
            }
            else
            {
                result.Succeeded = false;
                result.AddMessage(MessageType.LogicalError, "Appointment not found.");
            }
        }
        catch (Exception ex)
        {
            result.Succeeded = false;
            result.AddMessage(MessageType.Exception, $"An error occurred while retrieving the appointment: {ex.Message}");
        }

        return result;
    }

    public ResultObject<ICollection<AppointmentDTO>> GetAllAppointments(int doctorID)
    {
        ResultObject<ICollection<AppointmentDTO>> result = new ResultObject<ICollection<AppointmentDTO>>();

        try
        {
            ICollection<Core.Entities.Appointment> appointmentEntities = baseRepository.FindAll<Core.Entities.Appointment>(x => x.DoctorID == doctorID);

            if (appointmentEntities != null)
            {
                ICollection<AppointmentDTO> appointmentDTOs = new List<AppointmentDTO>();

                foreach (var appointmentEntity in appointmentEntities)
                {
                    AppointmentDTO appointmentDTO = new AppointmentDTO
                    {
                        AppointmentID = appointmentEntity.AppointmentID,
                        DoctorID = appointmentEntity.DoctorID,
                        PatientID = appointmentEntity.PatientID,
                        AppointmentDate = appointmentEntity.AppointmentDate,
                        StartTime = appointmentEntity.StartTime,
                        // EndTime = appointmentEntity.EndTime,
                        // TreatmentType = appointmentEntity.TreatmentType,
                        Status = appointmentEntity.Status
                    };

                    appointmentDTOs.Add(appointmentDTO);
                }

                result.Result = appointmentDTOs;
                result.Succeeded = true;
            }
            else
            {
                result.Succeeded = false;
                result.AddMessage(MessageType.LogicalError, "Appointments not found.");
            }
        }
        catch (Exception ex)
        {
            result.Succeeded = false;
            result.AddMessage(MessageType.Exception, $"An error occurred while retrieving the appointments: {ex.Message}");
        }

        return result;
    }

    public ResultObject<ICollection<AppointmentDTO>> GetAllAppointments(int doctorID, int patientID)
    {
        ResultObject<ICollection<AppointmentDTO>> result = new ResultObject<ICollection<AppointmentDTO>>();

        try
        {
            ICollection<Core.Entities.Appointment> appointmentEntities = baseRepository.FindAll<Core.Entities.Appointment>(x => x.DoctorID == doctorID && x.PatientID == patientID);

            if (appointmentEntities != null)
            {
                ICollection<AppointmentDTO> appointmentDTOs = new List<AppointmentDTO>();

                foreach (var appointmentEntity in appointmentEntities)
                {
                    AppointmentDTO appointmentDTO = new AppointmentDTO
                    {
                        AppointmentID = appointmentEntity.AppointmentID,
                        DoctorID = appointmentEntity.DoctorID,
                        PatientID = appointmentEntity.PatientID,
                        AppointmentDate = appointmentEntity.AppointmentDate,
                        StartTime = appointmentEntity.StartTime,
                        // EndTime = appointmentEntity.EndTime,
                        // TreatmentType = appointmentEntity.TreatmentType,
                        Status = appointmentEntity.Status
                    };

                    appointmentDTOs.Add(appointmentDTO);
                }

                result.Result = appointmentDTOs;
                result.Succeeded = true;
            }
            else
            {
                result.Succeeded = false;
                result.AddMessage(MessageType.LogicalError, "Appointments not found.");
            }
        }
        catch (Exception ex)
        {
            result.Succeeded = false;
            result.AddMessage(MessageType.Exception, $"An error occurred while retrieving the appointments: {ex.Message}");
        }

        return result;
    }

    public ResultObject<bool> AddAppointment(AppointmentDTO appointmentDTO)
    {
        ResultObject<bool> result = new ResultObject<bool>();

        try
        {
            Core.Entities.Appointment appointmentEntity = new Core.Entities.Appointment
            {
                DoctorID = appointmentDTO.DoctorID,
                PatientID = appointmentDTO.PatientID,
                AppointmentDate = appointmentDTO.AppointmentDate,
                StartTime = appointmentDTO.StartTime,
                // EndTime = appointmentDTO.EndTime,
                // TreatmentType = appointmentDTO.TreatmentType,
                Status = appointmentDTO.Status
            };

            baseRepository.Add(appointmentEntity);
            unitOfWork.Commit();

            result.Result = true;
            result.Succeeded = true;
        }
        catch (Exception ex)
        {
            result.Succeeded = false;
            result.AddMessage(MessageType.Exception, $"An error occurred while adding the appointment: {ex.Message}");
        }

        return result;
    }

    public ResultObject<bool> UpdateAppointment(AppointmentDTO appointmentDTO)
    {
        ResultObject<bool> result = new ResultObject<bool>();

        try
        {
            Core.Entities.Appointment appointmentEntity = baseRepository.Get<Core.Entities.Appointment>(appointmentDTO.AppointmentID);

            if (appointmentEntity != null)
            {
                appointmentEntity.AppointmentID = appointmentDTO.AppointmentID;
                appointmentEntity.DoctorID = appointmentDTO.DoctorID;
                appointmentEntity.PatientID = appointmentDTO.PatientID;
                appointmentEntity.AppointmentDate = appointmentDTO.AppointmentDate;
                appointmentEntity.StartTime = appointmentDTO.StartTime;
                // appointmentEntity.EndTime = appointmentDTO.EndTime;
                // appointmentEntity.TreatmentType = appointmentDTO.TreatmentType;
                appointmentEntity.Status = appointmentDTO.Status;

                baseRepository.Update(appointmentEntity, appointmentEntity.AppointmentID);
                unitOfWork.Commit();

                result.Result = true;
                result.Succeeded = true;
            }
            else
            {
                result.Succeeded = false;
                result.AddMessage(MessageType.LogicalError, "Appointment not found.");
            }
        }
        catch (Exception ex)
        {
            result.Succeeded = false;
            result.AddMessage(MessageType.Exception, $"An error occurred while updating the appointment: {ex.Message}");
        }

        return result;
    }

    public ResultObject<bool> DeleteAppointment(int appointmentID)
    {
        ResultObject<bool> result = new ResultObject<bool>();

        try
        {
            Core.Entities.Appointment appointmentEntity = baseRepository.Get<Core.Entities.Appointment>(appointmentID);

            if (appointmentEntity != null)
            {
                baseRepository.Delete(appointmentEntity);
                unitOfWork.Commit();

                result.Result = true;
                result.Succeeded = true;
            }
            else
            {
                result.Succeeded = false;
                result.AddMessage(MessageType.LogicalError, "Appointment not found.");
            }
        }
        catch (Exception ex)
        {
            result.Succeeded = false;
            result.AddMessage(MessageType.Exception, $"An error occurred while deleting the appointment: {ex.Message}");
        }

        return result;
    }
}