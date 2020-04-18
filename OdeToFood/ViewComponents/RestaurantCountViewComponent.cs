using Microsoft.AspNetCore.Mvc;
using OdeToFood.Data;

namespace OdeToFood.ViewComponents
{
    public class RestaurantCountViewComponent : ViewComponent
    {
        private readonly IRestaurantRepository _repository;

        public RestaurantCountViewComponent(IRestaurantRepository repository)
        {
            this._repository = repository;
        }

        public IViewComponentResult Invoke() 
        {
            int count = _repository.GetCount();

            return View(count);
        }
    }
}
