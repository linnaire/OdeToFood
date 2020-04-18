using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OdeToFood.Core;
using OdeToFood.Data;

namespace OdeToFood.Pages.Restaurants
{
    public class DetailModel : PageModel
    {
        private readonly IRestaurantRepository _repository;

        [BindProperty]
        public Restaurant Restaurant { get; set; }

        public DetailModel(IRestaurantRepository repository)
        {
            this._repository = repository;
        }

        [TempData]
        public string Message { get; set; }

        public IActionResult OnGet(int id)
        {
            if (_repository.Exists(id))
            {
                Restaurant = _repository.FindById(id);

                return Page();
            }

            return RedirectToPage("/NotFound");
        }
    }
}