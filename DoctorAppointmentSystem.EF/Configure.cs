using DoctorAppointmentSystem.Core.UOW;
using Microsoft.Extensions.DependencyInjection;

namespace DoctorAppointmentSystem.EF;

public class Configure
{
    public static void ConfigureServices(IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IBaseRepository, BaseRepository>();
    }
}