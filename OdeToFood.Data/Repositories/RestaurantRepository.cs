using Microsoft.EntityFrameworkCore;
using OdeToFood.Core;
using System.Collections.Generic;
using System.Linq;

namespace OdeToFood.Data
{
    public class RestaurantRepository : IRestaurantRepository
    {
        #region private properties
        private readonly ApplicationDbContext _context;
        #endregion

        #region constructor
        public RestaurantRepository(ApplicationDbContext context)
        {
            this._context = context;
        }
        #endregion

        #region navigations

        public bool Exists(int id)
        {
            return _context.Restaurants.Any(x => x.Id == id);
        }

        public IEnumerable<Restaurant> FindAll()
        {
            return _context.Restaurants.ToList().OrderBy(x => x.Id);
        }

        public Restaurant FindById(int id)
        {
            return _context.Restaurants.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Restaurant> GetRestaurantByName(string name)
        {
            return _context.Restaurants.ToList()
                               .Where(
                                    x => string.IsNullOrEmpty(name) ||
                                    x.Name.StartsWith(name)
                               );
        }
        #endregion

        #region crud
        public Restaurant Create(Restaurant model)
        {
            _context.Restaurants.Add(model);

            return model;
        }

        public Restaurant Delete(int id)
        {
            Restaurant restaurant = FindById(id);

            if (restaurant != null)
            {
                _context.Restaurants.Remove(restaurant);
            }

            return restaurant;
        }

        public Restaurant Update(Restaurant model)
        {
            var restaurant = _context.Restaurants.Attach(model);

            restaurant.State = EntityState.Modified;

            return model;
           
        }

        public bool Save()
        {
            return _context.SaveChanges() > 0;
        } 
        #endregion
    }
}
