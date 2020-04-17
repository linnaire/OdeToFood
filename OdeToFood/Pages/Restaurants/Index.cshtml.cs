using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using OdeToFood.Core;
using OdeToFood.Data;
using System.Collections.Generic;

namespace OdeToFood.Pages.Restaurants
{
    public class IndexModel : PageModel
    {
        private readonly IConfiguration _config;
        private readonly IRestaurantRepository _repository;

        public string Message { get; set; }
        public IEnumerable<Restaurant> Restaurants { get; set; }

        public IndexModel(IConfiguration config, IRestaurantRepository repository)
        {
            this._config = config;
            this._repository = repository;
        }

        public void OnGet()
        {
            Message = this._config["Message"];
            Restaurants = _repository.GetAll();
        }
    }
}
