using Microsoft.AspNetCore.Mvc;
using NutritionWatcher.Models;
using NutritionWatcher.ViewModels;
using NutritionWatcher.Services;

namespace NutritionWatcher.Controllers
{
    public class FoodController : Controller
    {
        private FoodFormModel foodFormModel { get; set; }

        public FoodController()
        {

        }

        public IActionResult Index()
        {
            foodFormModel = new FoodFormModel();
            return View("FoodForm", foodFormModel);
        }

        [HttpPost]
        public IActionResult SubmitForm(FoodFormModel foodForm)
        {
            if (!ModelState.IsValid)
            {
                return View("FoodForm");
            }
            return RedirectToAction("Index", "Home");
        }
    }
}
