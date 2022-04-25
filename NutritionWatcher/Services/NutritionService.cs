using NutritionWatcher.Interfaces;
using NutritionWatcher.Models;

using Microsoft.AspNetCore.WebUtilities;

using System.Text.Json;

namespace NutritionWatcher.Services
{
    public class NutritionService : INutritionService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        public NutritionService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }

        public async Task<NutritionModel[]> GetNutritionList()
        {
            // get our secrets
            var API_KEY = _configuration["api_key"];

            var query = new Dictionary<string, string>();
            query.Add("api_key", API_KEY);

            // combine base url with query string
            var response = await _httpClient.GetAsync(QueryHelpers.AddQueryString(_httpClient.BaseAddress.ToString(), query));

            response.EnsureSuccessStatusCode();

            var responseBody = await response.Content.ReadAsStringAsync();

            var foodList = JsonSerializer.Deserialize<NutritionModel[]>(responseBody);

            return foodList;
        }
    }
}
