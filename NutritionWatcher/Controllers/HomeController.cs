using Microsoft.AspNetCore.Mvc;
using NutritionWatcher.Models;
using NutritionWatcher.ViewModels;
using NutritionWatcher.Services;
using System.Diagnostics;

using System.Text.Json;

namespace NutritionWatcher.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private GreetingPickerService _greetingPickerService;

        private MainPageViewModel _mainPageViewModel { get; set; }

        private readonly IHttpClientFactory _httpClientFactory;

        public HomeController(ILogger<HomeController> logger, GreetingPickerService greetingPickerService, IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
            _greetingPickerService = greetingPickerService;
            _httpClientFactory = httpClientFactory;
        }

        public IActionResult Index()
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

        [HttpPost]
        public async Task<IActionResult> RetrieveNutritionList(int NumberOfFood, MainPageViewModel mainPageViewModel)
        {
            HttpClient httpClient = _httpClientFactory.CreateClient();

            var requestBody = new Dictionary<string, string>();
            requestBody.Add("pageSize", NumberOfFood.ToString());

            var request = new HttpRequestMessage()
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://localhost:7223/nutrition_list"),
            };

            var response = await httpClient.SendAsync(request);

            var responseBody = await response.Content.ReadAsStringAsync();

            mainPageViewModel.NutritionList = JsonSerializer.Deserialize<NutritionModel[]>(responseBody);

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