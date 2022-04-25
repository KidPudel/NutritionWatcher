using NutritionWatcher.Models;
using System.ComponentModel.DataAnnotations;

namespace NutritionWatcher.ViewModels
{
    public class MainPageViewModel
    {
        [Required]
        public string UserName { get; set; }
        public string Greeting { get; set; }

        public IEnumerable<NutritionModel> NutritionList { get; set; }

        public int NumberOfFood { get; set; }
    }
}
