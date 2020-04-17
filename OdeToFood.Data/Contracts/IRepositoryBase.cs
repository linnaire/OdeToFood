using System.Collections.Generic;

namespace OdeToFood.Data
{
    public interface IRepositoryBase<T> where T : class
    {
        IEnumerable<T> GetAll();
    }
}
