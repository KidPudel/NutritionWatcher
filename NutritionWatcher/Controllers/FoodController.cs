using Microsoft.AspNetCore.Mvc;
using NutritionWatcher.Models;
using NutritionWatcher.ViewModels;
using NutritionWatcher.Services;

namespace NutritionWatcher.Controllers
{
    public class FoodController : Controller
    {
        private FoodModel _FoodModel { get; set; }

        private FoodViewModel _FoodViewModel { get; set; } = new FoodViewModel();

        private JsonFileFoodService FoodService { get; set; }

        public FoodController(JsonFileFoodService foodService)
        {
            FoodService = foodService;
        }

        // food form
        public IActionResult Index()
        {
            _FoodModel = new FoodModel();
            return View("FoodForm", _FoodModel);
        }

        [HttpPost]
        public IActionResult SubmitForm(FoodModel foodForm)
        {
            if (!ModelState.IsValid)
            {
                return View("FoodForm");
            }
            FoodService.AddFood(foodForm);

            return RedirectToAction("Index", "Home");
        }

        public IActionResult FoodList()
        {
            var food = FoodService.GetFood();
            _FoodViewModel.FoodList = food;

            return View(_FoodViewModel);
        }
    }
}
