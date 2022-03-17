using Microsoft.AspNetCore.Mvc;
using NutritionWatcher.Models;
using NutritionWatcher.ViewModels;
using NutritionWatcher.Services;
using System.Diagnostics;

namespace NutritionWatcher.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private GreetingPickerService _greetingPickerService;

        private MainPageViewModel _mainPageViewModel { get; set; }

        public HomeController(ILogger<HomeController> logger, GreetingPickerService greetingPickerService)
        {
            _logger = logger;
            _greetingPickerService = greetingPickerService;
        }

        public IActionResult Index(string userName)
        {
            _mainPageViewModel = new MainPageViewModel();
            return View(_mainPageViewModel);
        }

        [HttpPost]
        public IActionResult Greeting(string userName, MainPageViewModel mainPageViewModel)
        {
            mainPageViewModel.Greeting = _greetingPickerService.Greeting(userName);
            return View("Index", mainPageViewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}