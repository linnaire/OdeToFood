using System.Collections.Generic;

namespace OdeToFood.Data
{
    public interface IRepositoryBase<T> where T : class
    {
        IEnumerable<T> FindAll();
        T FindById(int id);
        bool Exists(int id);
        T Update(T model);
        T Create(T model);
        T Delete(int id);
        bool Save();
    }
}
