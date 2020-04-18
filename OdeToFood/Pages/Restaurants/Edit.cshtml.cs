using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using OdeToFood.Core;
using OdeToFood.Data;
using System.Collections.Generic;

namespace OdeToFood.Pages.Restaurants
{
    public class EditModel : PageModel
    {
        private readonly IRestaurantRepository _repository;

        private readonly IHtmlHelper _htmlHelper;

        [BindProperty]
        public Restaurant Restaurant { get; set; }

        public IEnumerable<SelectListItem> Cuisines { get; set; }

        public string PageHeader { get; set; }

        public EditModel(IRestaurantRepository repository,
                         IHtmlHelper htmlHelper)
        {
            this._repository = repository;
            this._htmlHelper = htmlHelper;
        }

        public IActionResult OnGet(int? id)
        {
            Cuisines = _htmlHelper.GetEnumSelectList<CuisineType>();

            Restaurant = new Restaurant();

            PageHeader = $"Register Restaurant";

            if (id.HasValue)
            {
                if (!_repository.Exists(id.Value)) return RedirectToPage("/NotFound");

                Restaurant = _repository.FindById(id.Value);

                PageHeader = $"Update {Restaurant.Name}";
            }

            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                Cuisines = _htmlHelper.GetEnumSelectList<CuisineType>();

                PageHeader = (Restaurant.Id > 0) ? $"Update {Restaurant.Name}" : $"Register Restaurant";

                return Page();
            }

            if (Restaurant.Id > 0)
                _repository.Update(Restaurant);
            else
                _repository.Create(Restaurant);

            _repository.Save();

            TempData["Message"] = $"Restaurant: {Restaurant.Name} successfully saved!";

            return RedirectToPage("./Detail", new { id = Restaurant.Id });
        }
    }
}