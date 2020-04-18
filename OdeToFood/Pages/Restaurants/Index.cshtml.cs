using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using OdeToFood.Core;
using OdeToFood.Data;
using System.Collections.Generic;

namespace OdeToFood.Pages.Restaurants
{
    public class IndexModel : PageModel
    {
        #region privates readonly properties
        private readonly IRestaurantRepository _repository;
        #endregion

        #region public properties
        public IEnumerable<Restaurant> Restaurants { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }
        #endregion

        #region constructor
        public IndexModel(IRestaurantRepository repository)
        {
            this._repository = repository;
        }
        #endregion

        #region actions
        public void OnGet()
        {
            Restaurants = _repository.GetRestaurantByName(SearchTerm);
        } 
        #endregion
    }
}
