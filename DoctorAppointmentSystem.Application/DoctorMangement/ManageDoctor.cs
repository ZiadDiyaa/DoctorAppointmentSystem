using DoctorAppointmentSystem.Application.DTOs;
using DoctorAppointmentSystem.Core.Entities;
using DoctorAppointmentSystem.Core.UOW;

namespace DoctorAppointmentSystem.Application.DoctorMangement;

public class ManageDoctor:IManageDoctor
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IBaseRepository baseRepository;
    
    public ManageDoctor(IUnitOfWork unitOfWork, IBaseRepository baseRepository)
    {
        this.unitOfWork = unitOfWork;
        this.baseRepository = baseRepository;
        
    }
    
    public ResultObject<DoctorDTO> GetDoctor(int doctorID)
    {
        ResultObject<DoctorDTO> result = new ResultObject<DoctorDTO>();

        try
        {
            var doctor = baseRepository.Get<Doctor>(doctorID); 

            if (doctor != null)
            {
                DoctorDTO doctorResult = new DoctorDTO
                {
                    DoctorID = doctor.DoctorID,
                    FirstName = doctor.FirstName,
                    LastName = doctor.LastName,
                    Email = doctor.Email,
                    PhoneNumber = doctor.PhoneNumber,
                    Rating = doctor.Rating,
                    Specialization = doctor.Specialization,
                    DateOfBirth = doctor.DateOfBirth,
                    IsAvailable = doctor.IsAvailable, 
                    Appointments = doctor.Appointments?.Select(a => new AppointmentDTO
                    {
                        AppointmentID = a.AppointmentID,
                        PatientID = a.PatientID,
                        DoctorID = a.DoctorID,
                        AppointmentDate = a.AppointmentDate,
                        StartTime = a.StartTime,
                        Status = a.Status
                    }).ToList()
                };

                result.Result = doctorResult;
                result.Succeeded = true;
            }
            else
            {
                result.Succeeded = false;
                result.AddMessage(MessageType.LogicalError, "Doctor not found.");
            }
        }
        catch (Exception ex)
        {
            result.Succeeded = false;
            result.AddMessage(MessageType.Exception, $"An error occurred while retrieving the doctor: {ex.Message}");
        }

        return result;
    }
    public ResultObject<ICollection<DoctorDTO>> GetAllDoctors()
    {
        ResultObject<ICollection<DoctorDTO>> result = new ResultObject<ICollection<DoctorDTO>>();

        try
        {
            var doctors = baseRepository.GetAll<Doctor>();

            if (doctors != null)
            {
                result.Result = doctors.Select(doctor => new DoctorDTO
                {
                    DoctorID = doctor.DoctorID,
                    FirstName = doctor.FirstName,
                    LastName = doctor.LastName,
                    Email = doctor.Email,
                    PhoneNumber = doctor.PhoneNumber,
                    Rating = doctor.Rating,
                    Specialization = doctor.Specialization,
                    DateOfBirth = doctor.DateOfBirth,
                    IsAvailable = doctor.IsAvailable,
                    Appointments = doctor.Appointments?.Select(a => new AppointmentDTO
                    {
                        AppointmentID = a.AppointmentID,
                        PatientID = a.PatientID,
                        DoctorID = a.DoctorID,
                        AppointmentDate = a.AppointmentDate,
                        StartTime = a.StartTime,
                        Status = a.Status
                    }).ToList()
                }).ToList();
            
                result.Succeeded = true;
            }
            else
            {
                result.Succeeded = false;
                result.AddMessage(MessageType.LogicalError, "Doctors not found.");
            }
        }
        catch (Exception ex)
        {
            result.Succeeded = false;
            result.AddMessage(MessageType.Exception, $"An error occurred while retrieving the doctors: {ex.Message}");
        }

        return result;
    }

    public ResultObject<bool> AddDoctor(DoctorDTO doctorDTO)
    {
        ResultObject<bool> result = new ResultObject<bool>();

        if(doctorDTO == null)
        {
            result.Succeeded = false;
            result.AddMessage(MessageType.LogicalError, "No doctor data found");
        }
        else
        {
            try
            {
                Doctor doctor = new Doctor
                {
                    FirstName = doctorDTO.FirstName,
                    LastName = doctorDTO.LastName,
                    Email = doctorDTO.Email,
                    PhoneNumber = doctorDTO.PhoneNumber,
                    Rating = doctorDTO.Rating,
                    Specialization = doctorDTO.Specialization,
                    DateOfBirth = doctorDTO.DateOfBirth,
                    IsAvailable = doctorDTO.IsAvailable  
                };

                baseRepository.Add(doctor);
                unitOfWork.Commit();
                result.Succeeded = true;
                result.Result = true;
            }
            catch (Exception ex)
            {
                result.Succeeded = false;
                result.AddMessage(MessageType.Exception, $"An error occurred while adding the doctor: {ex.Message}");
            }
        }

        return result;
    }

    public ResultObject<bool> UpdateDoctor(DoctorDTO doctorDTO)
    {
        ResultObject<bool> result = new ResultObject<bool>();

        if (doctorDTO == null)
        {
            result.Succeeded = false;
            result.AddMessage(MessageType.LogicalError, "No doctor data found");
        }
        else
        {
            try
            {
                DoctorDTO doctor = baseRepository.Get<DoctorDTO>(doctorDTO.DoctorID);

                if (doctor != null)
                {
                    doctor.FirstName = doctorDTO.FirstName;
                    doctor.LastName = doctorDTO.LastName;
                    doctor.Email = doctorDTO.Email;
                    doctor.PhoneNumber = doctorDTO.PhoneNumber;
                    doctor.Rating = doctorDTO.Rating;
                    doctor.Specialization = doctorDTO.Specialization;
                    doctor.DateOfBirth = doctorDTO.DateOfBirth;
                    doctor.IsAvailable = doctorDTO.IsAvailable;

                    baseRepository.Update(doctor, doctor.DoctorID);
                    unitOfWork.Commit();
                    result.Succeeded = true;
                    result.Result = true;
                }
                else
                {
                    result.Succeeded = false;
                    result.AddMessage(MessageType.LogicalError, "Doctor not found.");
                }
            }
            catch (Exception ex)
            {
                result.Succeeded = false;
                result.AddMessage(MessageType.Exception, $"An error occurred while updating the doctor: {ex.Message}");
            }
        }

        return result;
    }

    public ResultObject<bool> DeleteDoctor(int doctorID)
    {
        ResultObject<bool> result = new ResultObject<bool>();

        try
        {
            DoctorDTO doctor = baseRepository.Get<DoctorDTO>(doctorID);

            if (doctor != null)
            {
                baseRepository.Delete(doctor);
                unitOfWork.Commit();
                result.Succeeded = true;
                result.Result = true;
            }
            else
            {
                result.Succeeded = false;
                result.AddMessage(MessageType.LogicalError, "Doctor not found.");
            }
        }
        catch (Exception ex)
        {
            result.Succeeded = false;
            result.AddMessage(MessageType.Exception, $"An error occurred while deleting the doctor: {ex.Message}");
        }

        return result;
    }

    public ResultObject<ICollection<DoctorDTO>> GetAvailableDoctors()
    {
        ResultObject<ICollection<DoctorDTO>> result = new ResultObject<ICollection<DoctorDTO>>();

        try
        {
            ICollection<DoctorDTO> availableDoctors = baseRepository.GetAll<DoctorDTO>()
                .Where(d => d.IsAvailable) 
                .ToList();

            if (availableDoctors != null && availableDoctors.Any())
            {
                result.Result = availableDoctors;
                result.Succeeded = true;
            }
            else
            {
                result.Succeeded = false;
                result.AddMessage(MessageType.LogicalError, "No available doctors found.");
            }
        }
        catch (Exception ex)
        {
            result.Succeeded = false;
            result.AddMessage(MessageType.Exception, $"An error occurred while retrieving available doctors: {ex.Message}");
        }

        return result;
    }
}