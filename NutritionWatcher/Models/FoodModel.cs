using System.ComponentModel.DataAnnotations;

namespace NutritionWatcher.Models
{
    public class FoodModel
    {
        [Required (AllowEmptyStrings = false, ErrorMessage = "Please enter a food name")]
        [Display(Name = "What you've eaten")]
        public string FoodName { get; set; }

        [Required (AllowEmptyStrings = false, ErrorMessage = "Please specify number of callories in 100g")]
        [Display(Name = "How many callories in 100g")]
        public int Callories { get; set; }

        [Required (AllowEmptyStrings = false, ErrorMessage = "Please specify number of grams")]
        [Display(Name = "Number of grams")]
        public int Grams { get; set; } = 100;

    }
}
