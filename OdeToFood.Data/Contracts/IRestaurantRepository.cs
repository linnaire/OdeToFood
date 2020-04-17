using OdeToFood.Core;
using System.Collections.Generic;

namespace OdeToFood.Data
{
    public interface IRestaurantRepository : IRepositoryBase<Restaurant> 
    {
        IEnumerable<Restaurant> GetRestaurantByName(string name);
    }
}
