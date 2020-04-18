using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OdeToFood.Core;
using OdeToFood.Data;

namespace OdeToFood.Pages.Restaurants
{
    public class DeleteModel : PageModel
    {
        private readonly IRestaurantRepository _repository;

        public Restaurant Restaurant { get; set; }

        public DeleteModel(IRestaurantRepository repository)
        {
            this._repository = repository;
        }

        public IActionResult OnGet(int id)
        {
            Restaurant = _repository.FindById(id);

            if (Restaurant == null) return RedirectToPage("/NotFound");

            return Page();
        }

        public IActionResult OnPost(int id) 
        {
            var restaurant = _repository.Delete(id);

            _repository.Save();

            if (restaurant == null) return RedirectToPage("/NotFound");

            TempData["Message"] = $"{restaurant.Name} was successfully removed from the list.";

            return RedirectToPage("/Restaurants/Index");
        }
    }
}