using DoctorAppointmentSystem.Application.AccountDetails;
using DoctorAppointmentSystem.Application.AppointmentManagement;
using DoctorAppointmentSystem.Application.ConsumableMangement;
using DoctorAppointmentSystem.Application.DoctorMangement;
using DoctorAppointmentSystem.Application.PatientManagement;
using DoctorAppointmentSystem.Application.TimeslotManagement;
using DoctorAppointmentSystem.Application.TreatmentRecordManagement;
using Microsoft.Extensions.DependencyInjection;

namespace DoctorAppointmentSystem.Application;

public class Configure
{
    public static void ConfigureService(IServiceCollection services)
    {
        services.AddTransient<IManageAdmin, ManageAdmin>();
        services.AddTransient<IManageAccountDetails, ManageAccountDetails>();
        services.AddTransient<IManageDoctor, ManageDoctor>();
        services.AddTransient<IManagePatient, ManagePatient>();
        services.AddTransient<IManageTimeslot, ManageTimeslot>();
        services.AddTransient<IManageTreatmentRecord, ManageTreatmentRecord>();
        services.AddTransient<IManageAccountDetails, ManageAccountDetails>();
        services.AddTransient<IManageAdmin, ManageAdmin>();
        services.AddTransient<IManageAppointment, ManageAppointment>();
        services.AddTransient<IManageConsumable, ManageConsumable>();
        services.AddTransient<IManageDoctor, ManageDoctor>();
        



    }
}