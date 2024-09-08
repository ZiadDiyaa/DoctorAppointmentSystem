using System.Linq.Expressions;

namespace DoctorAppointmentSystem.Core.UOW;

public interface IBaseRepository
{
    T? Get<T>(object id) where T : class;
    ICollection<T> GetAll<T>(bool noTraching = false) where T : class;
    ICollection<T> GetAll<T>(string[] includes, bool noTraching = false) where T : class;

    T? First<T>(Expression<Func<T, bool>> match, string[]? Includes = null) where T : class;
    T? Find<T>(Expression<Func<T, bool>> match, string[]? Includes = null) where T : class;
    ICollection<T> FindAll<T>(Expression<Func<T, bool>> match, string[]? Includes = null) where T : class;
    ICollection<T> FindAll<T, TKey>(Expression<Func<T, bool>> match, int Take, int Skip, Expression<Func<T, TKey>> OrderBy, string[]? Includes = null) where T : class;

    T Add<T>(T t) where T : class;
    IEnumerable<T> AddAll<T>(IEnumerable<T> tList) where T : class;

    T? Update<T>(T updated, int key) where T : class;

    void Delete<T>(T t) where T : class;
    void Delete<T>(List<T> t) where T : class;

    int Count<T>() where T : class;
    int Count<T>(Expression<Func<T, bool>> match) where T : class;
    int Count<T>(Expression<Func<T, bool>> match, string[]? Includes = null) where T : class;

    bool Any<T>(Expression<Func<T, bool>> match) where T : class;
}