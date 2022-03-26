using NutritionWatcher.Models;

namespace NutritionWatcher.ViewModels
{
    public class FoodViewModel
    {
        public IEnumerable<FoodModel> FoodList { get; set; } = new List<FoodModel>();
    }
}
