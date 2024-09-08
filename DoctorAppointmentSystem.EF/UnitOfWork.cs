using System.Data;
using System.Data.SqlClient;
using DoctorAppointmentSystem.Core;
using DoctorAppointmentSystem.Core.UOW;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Configuration;

namespace DoctorAppointmentSystem.EF;

  public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext context;
        private readonly IConfiguration configuration;

        public UnitOfWork(ApplicationDbContext context, IConfiguration configuration)
        {
            this.configuration = configuration;
            this.context = context;
        }
        public void Commit()
        {
            context.SaveChanges();
        }

        private bool _isDisposed = false;

        public void Dispose()
        {
            if (_isDisposed)
                return;
            _isDisposed = true;
            context.Dispose();
        }

        public EntityEntry Entry(object entity)
        {
            return context.Entry(entity);
        }

        public DataSet ExecuteCommand(string procedureName, params SqlParameter[] commandParameters)
        {
            DataSet result = new DataSet();
            SqlCommand command = new SqlCommand(procedureName);
            command.Connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
            command.CommandType = CommandType.StoredProcedure;
            if (commandParameters != null)
            {
                command.Parameters.AddRange(commandParameters);
            }
            command.Connection.Open();
            using (SqlDataAdapter da = new SqlDataAdapter(command))
            {
                da.Fill(result);
            }
            command.Connection.Close();
            return result;
        }

        public object ExecuteScalar(string procedureName, params SqlParameter[] commandParameters)
        {
            SqlCommand command = new SqlCommand(procedureName);
            command.Connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
            command.CommandType = CommandType.StoredProcedure;
            if (commandParameters != null)
            {
                command.Parameters.AddRange(commandParameters);
            }
            command.Connection.Open();
            var result = command.ExecuteScalar();
            command.Connection.Close();
            return result;
        }

        public int ExecuteSqlCommand(string sql, object[] parameters)
        {
            if (parameters != null)
            {
                return context.Database.ExecuteSqlRaw(sql, parameters);
            }
            else
            {
                return context.Database.ExecuteSqlRaw(sql);
            }
        }

        public DbSet<T> Set<T>() where T : class
        {
            return context.Set<T>();
        }
    }