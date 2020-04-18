using OdeToFood.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OdeToFood.Data
{
    public class RestaurantRepository : IRestaurantRepository
    {
        private List<Restaurant> _restaurants;

        public RestaurantRepository()
        {
            _restaurants = new List<Restaurant>()
            {
                new Restaurant { Id = 1, Name = "Scott's Pizza", Location = "Maryland", Cuisine = CuisineType.Italian},
                new Restaurant { Id = 2, Name = "Cinammon Club", Location = "London", Cuisine = CuisineType.Indian},
                new Restaurant { Id = 3, Name = "La Costa", Location = "California", Cuisine = CuisineType.Mexican},
            };
        }

        public Restaurant Create(Restaurant model)
        {
            model.Id = _restaurants.Max(x => x.Id) + 1;

            _restaurants.Add(model);

            return model;
        }

        public bool Exists(int id)
        {
            return _restaurants.Any(x => x.Id == id);
        }

        public IEnumerable<Restaurant> FindAll()
        {
            return _restaurants.ToList().OrderBy(x => x.Id);
        }

        public Restaurant FindById(int id)
        {
            return _restaurants.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Restaurant> GetRestaurantByName(string name)
        {
            return _restaurants.ToList()
                               .Where(
                                    x => string.IsNullOrEmpty(name) ||
                                    x.Name.StartsWith(name)
                               );
        }

        public bool Save()
        {
            return true;
        }

        public Restaurant Update(Restaurant model)
        {
            if (Exists(model.Id))
            {
                var restaurant = FindById(model.Id);

                restaurant.Name = model.Name;

                restaurant.Location = model.Location;

                restaurant.Cuisine = model.Cuisine;

                return restaurant;
            }

            return null;
        }
    }
}
