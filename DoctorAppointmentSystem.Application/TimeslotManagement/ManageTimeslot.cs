using DoctorAppointmentSystem.Application.DTOs;
using DoctorAppointmentSystem.Core.Entities;
using DoctorAppointmentSystem.Core.UOW;

namespace DoctorAppointmentSystem.Application.TimeslotManagement;

public class ManageTimeslot: IManageTimeslot

{
    
    private readonly IUnitOfWork _unitOfWork;
    private readonly  IBaseRepository _baseRepository;
    
    public ManageTimeslot(IBaseRepository baseRepository, IUnitOfWork unitofwork)
    {
        _baseRepository = baseRepository;
        _unitOfWork = unitofwork;
    }
    public ResultObject<TimeSlotDTO> GetTimeSlot(int timeSlotID)
    {
        ResultObject<TimeSlotDTO> result = new ResultObject<TimeSlotDTO>();
        try
        {
            var timeSlot = _baseRepository.Get<TimeSlot>(timeSlotID);

            if (timeSlot != null)
            {
                TimeSlotDTO timeSlotDTO = new TimeSlotDTO
                {
                    TimeSlotID = timeSlot.TimeSlotID,
                    DoctorID = timeSlot.DoctorID,
                    StartTime = timeSlot.StartTime,
                    EndTime = timeSlot.EndTime,
                    isAvailable = timeSlot.isAvailable
                };

                result.Succeeded = true;
                result.Result = timeSlotDTO;
            }
            else
            {
                result.Succeeded = false;
                result.AddMessage(MessageType.LogicalError, "Time slot not found.");
            }
        }
        catch (Exception e)
        {
            result.Succeeded = false;
            result.AddMessage(MessageType.Exception, $"An error occurred while retrieving the time slot: {e.Message}");
        }

        return result;
    }

    public ResultObject<ICollection<TimeSlotDTO>> GetAllTimeSlots()
    {
        ResultObject<ICollection<TimeSlotDTO>> result = new ResultObject<ICollection<TimeSlotDTO>>();
        try
        {
            var timeSlots = _baseRepository.GetAll<TimeSlot>();

            if (timeSlots != null && timeSlots.Any())
            {
                List<TimeSlotDTO> timeSlotDTOs = timeSlots.Select(timeSlot => new TimeSlotDTO
                {
                    TimeSlotID = timeSlot.TimeSlotID,
                    DoctorID = timeSlot.DoctorID,
                    StartTime = timeSlot.StartTime,
                    EndTime = timeSlot.EndTime,
                    isAvailable = timeSlot.isAvailable
                }).ToList();

                result.Succeeded = true;
                result.Result = timeSlotDTOs;
            }
            else
            {
                result.Succeeded = false;
                result.AddMessage(MessageType.LogicalError, "No time slots found.");
            }
        }
        catch (Exception e)
        {
            result.Succeeded = false;
            result.AddMessage(MessageType.Exception, $"An error occurred while retrieving the time slots: {e.Message}");
        }

        return result;
    }

    public ResultObject<bool> AddTimeSlot(TimeSlotDTO timeSlotDTO)
    {
        ResultObject<bool> result = new ResultObject<bool>();
        try
        {
            var timeSlot = new TimeSlot
            {
                DoctorID = timeSlotDTO.DoctorID,
                StartTime = timeSlotDTO.StartTime,
                EndTime = timeSlotDTO.EndTime,
                isAvailable = timeSlotDTO.isAvailable
            };

            _baseRepository.Add(timeSlot);
            _unitOfWork.Commit();

            result.Succeeded = true;
            result.Result = true;
        }
        catch (Exception e)
        {
            result.Succeeded = false;
            result.AddMessage(MessageType.Exception, $"An error occurred while adding the time slot: {e.Message}");
        }

        return result;
    }

    public ResultObject<bool> UpdateTimeSlot(TimeSlotDTO timeSlotDTO)
    {
        ResultObject<bool> result = new ResultObject<bool>();
        try
        {
            var timeSlot = _baseRepository.Get<TimeSlot>(timeSlotDTO.TimeSlotID);

            if (timeSlot != null)
            {
                timeSlot.DoctorID = timeSlotDTO.DoctorID;
                timeSlot.StartTime = timeSlotDTO.StartTime;
                timeSlot.EndTime = timeSlotDTO.EndTime;
                timeSlot.isAvailable = timeSlotDTO.isAvailable;

                _baseRepository.Update(timeSlot,timeSlotDTO.TimeSlotID);
                _unitOfWork.Commit();

                result.Succeeded = true;
                result.Result = true;
            }
            else
            {
                result.Succeeded = false;
                result.AddMessage(MessageType.LogicalError, "Time slot not found.");
            }
        }
        catch (Exception e)
        {
            result.Succeeded = false;
            result.AddMessage(MessageType.Exception, $"An error occurred while updating the time slot: {e.Message}");
        }

        return result;
    }

    public ResultObject<bool> DeleteTimeSlot(int TimeslotID)
    {
        ResultObject<bool> result = new ResultObject<bool>();
        try
        {
            var timeSlot = _baseRepository.Get<TimeSlot>(TimeslotID);

            if (timeSlot != null)
            {
                _baseRepository.Delete(timeSlot);
                _unitOfWork.Commit();

                result.Succeeded = true;
                result.Result = true;
            }
            else
            {
                result.Succeeded = false;
                result.AddMessage(MessageType.LogicalError, "Time slot not found.");
            }
        }
        catch (Exception e)
        {
            result.Succeeded = false;
            result.AddMessage(MessageType.Exception, $"An error occurred while deleting the time slot: {e.Message}");
        }

        return result;
    }
}