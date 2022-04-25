using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using NutritionWatcher.Models;
using NutritionWatcher.Services;
using NutritionWatcher.Interfaces;

namespace NutritionWatcher.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NutritionController : ControllerBase
    {
        private readonly INutritionService _nutritionService;
        public NutritionController(INutritionService nutritionService)
        {
            _nutritionService = nutritionService;
        }

        [HttpGet("/nutrition_list")]
        [Consumes("application/x-www-form-urlencoded")]
        public async Task<IActionResult> NutritionList()
        {
            var nutritionList = await _nutritionService.GetNutritionList();

            return Ok(nutritionList);
        }
    }
}
