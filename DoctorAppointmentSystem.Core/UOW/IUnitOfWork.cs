using System.Data;
using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace DoctorAppointmentSystem.Core.UOW;

public interface IUnitOfWork:IDisposable
{
    EntityEntry Entry(object entity);
    DbSet<T> Set<T>() where T : class;
    void Commit();
    int ExecuteSqlCommand(string sql, object[] parameters);
    DataSet ExecuteCommand(string procedureName, params SqlParameter[] commandParameters);
    object ExecuteScalar(string procedureName, params SqlParameter[] commandParameters);
      
}