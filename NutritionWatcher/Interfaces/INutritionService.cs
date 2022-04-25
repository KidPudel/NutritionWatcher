using NutritionWatcher.Models;

namespace NutritionWatcher.Interfaces
{
    public interface INutritionService
    {
        /// <summary>
        /// Method to get a list of food
        /// </summary>
        /// <returns></returns>
        Task<NutritionModel[]> GetNutritionList();
    }
}
