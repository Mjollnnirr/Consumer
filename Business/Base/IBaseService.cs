namespace Business.Base;

public interface IBaseService
{
    Task<T> Get<T>(int id);
    Task<List<T>> GetAll<T>();
    Task Create<T>(T entity);
    Task Update<T>(int id, T entity);
    Task Delete<T>(int id);
}

