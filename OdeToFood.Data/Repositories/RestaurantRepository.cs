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

        public IEnumerable<Restaurant> GetAll()
        {
            return _restaurants.ToList().OrderBy(x => x.Id);
        }
    }
}
