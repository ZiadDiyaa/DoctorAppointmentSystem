using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DoctorAppointmentSystem.Core;

public class Configure
{
    public static void ConfigureServices(IServiceCollection services, string connectionString)
    {
        services.AddDbContext<IdentityDbContext>(o=>o.UseNpgsql(connectionString));
        services.AddDbContext<ApplicationDbContext>(o => o.UseLazyLoadingProxies().UseNpgsql(connectionString));
    }
}