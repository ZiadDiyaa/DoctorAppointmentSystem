using System.Linq.Expressions;
using DoctorAppointmentSystem.Core.UOW;
using Microsoft.EntityFrameworkCore;

namespace DoctorAppointmentSystem.EF;

public class BaseRepository : IBaseRepository
{
    private readonly IUnitOfWork unitOfWork;

    public BaseRepository(IUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
    }

    public T Add<T>(T t) where T : class
    {
        unitOfWork.Set<T>().Add(t);
        return t;
    }

    public IEnumerable<T> AddAll<T>(IEnumerable<T> tList) where T : class
    {
        unitOfWork.Set<T>().AddRange(tList);
        return tList;
    }

    public bool Any<T>(Expression<Func<T, bool>> match) where T : class
    {
        return unitOfWork.Set<T>().Any(match);
    }

    public int Count<T>() where T : class
    {
        return unitOfWork.Set<T>().Count();
    }

    public int Count<T>(Expression<Func<T, bool>> match) where T : class
    {
        return unitOfWork.Set<T>().Count(match);
    }

    public int Count<T>(Expression<Func<T, bool>> match, string[]? Includes = null) where T : class
    {
        IQueryable<T> query = unitOfWork.Set<T>().Where(match);
        if (Includes != null)
        {
            foreach (var include in Includes)
            {
                query = query.Include(include);
            }
        }

        return query.Count();
    }

    public void Delete<T>(T t) where T : class
    {
        unitOfWork.Set<T>().Remove(t);
    }

    public void Delete<T>(List<T> t) where T : class
    {
        unitOfWork.Set<T>().RemoveRange(t);
    }

    public T? First<T>(Expression<Func<T, bool>> match, string[]? Includes = null) where T : class
    {
        IQueryable<T> query = unitOfWork.Set<T>();

        if (Includes != null)
        {
            foreach (var include in Includes)
            {
                query = query.Include(include);
            }
        }

        return query.FirstOrDefault(match);
    }

    public T? Find<T>(Expression<Func<T, bool>> match, string[]? Includes = null) where T : class
    {
        IQueryable<T> query = unitOfWork.Set<T>();

        if (Includes != null)
        {
            foreach (var include in Includes)
            {
                query = query.Include(include);
            }
        }

        return query.SingleOrDefault(match);
    }

    public ICollection<T> FindAll<T>(Expression<Func<T, bool>> match, string[]? Includes = null) where T : class
    {
        IQueryable<T> query = unitOfWork.Set<T>();
        if (Includes != null)
        {
            foreach (var include in Includes)
            {
                query = query.Include(include);
            }
        }

        return query.Where(match).ToList();
    }

    public ICollection<T> FindAll<T, TKey>(Expression<Func<T, bool>> match, int Take, int Skip,
        Expression<Func<T, TKey>> OrderBy, string[]? Includes = null) where T : class
    {
        IQueryable<T> query = unitOfWork.Set<T>();
        if (Includes != null)
        {
            foreach (var include in Includes)
            {
                query = query.Include(include);
            }
        }

        return query.Where(match).OrderByDescending(OrderBy).Skip(Skip).Take(Take).ToList();
    }

    public T? Get<T>(object id) where T : class
    {
        return unitOfWork.Set<T>().Find(id);
    }

    public ICollection<T> GetAll<T>(bool noTraching = false) where T : class
    {
        if (noTraching)
            return unitOfWork.Set<T>().AsNoTracking().ToList();
        else
            return unitOfWork.Set<T>().ToList();
    }

    public ICollection<T> GetAll<T>(string[] includes, bool noTraching = false) where T : class
    {
        IQueryable<T> query = unitOfWork.Set<T>();
        if (includes != null)
        {
            foreach (var include in includes)
            {
                query = query.Include(include);
            }
        }

        if (noTraching)
            return query.AsNoTracking().ToList();
        else
            return query.ToList();

    }

    public T? Update<T>(T updated, int key) where T : class
    {

        if (updated == null)
            return null;

        T? existing = unitOfWork.Set<T>().Find(key);
        if (existing != null)
        {
            unitOfWork.Entry(existing).CurrentValues.SetValues(updated);
        }

        return existing;
    }
}