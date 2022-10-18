using System;
namespace Business.Base;

public interface IBaseService<T>
{
    Task<T> Get(int id);
    Task<List<T>> GetAll();
    Task Create(T data);
    Task Update(int id, T data);
    Task Delete(int id);
}

