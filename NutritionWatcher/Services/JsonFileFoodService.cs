using System.Text.Json;
using Newtonsoft.Json;
using NutritionWatcher.Models;

namespace NutritionWatcher.Services
{
    public class JsonFileFoodService
    {
        // get current environment
        private IWebHostEnvironment _Environment { get; }

        public JsonFileFoodService(IWebHostEnvironment environment)
        {
            _Environment = environment;
        }

        public string JsonFileName { get
            {
                string filePath = Path.Combine(_Environment.WebRootPath, "Food", "food.json");
                // if file does not exists create one
                if (!File.Exists(filePath))
                {
                    CreateJsonFile(filePath);
                }
                return filePath;
            } }

        private void CreateJsonFile(string filePath)
        {
            string path = Path.Combine(_Environment.WebRootPath, "Food");

            // create directory
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }


            // create the file
            using (var stream = File.Create(filePath)) { }

            // serialize the specified empty list of FoodModel objects, to set parent class
            using (var outputStream = new StreamWriter(filePath))
            {
                outputStream.WriteLine(JsonConvert.SerializeObject(new List<FoodModel>()));
            }

            
        }

        /// <summary>
        /// Gets a list of food
        /// </summary>
        /// <returns></returns>
        public IList<FoodModel>? GetFood()
        {
            // get food list
            using (var jsonFileReader = File.OpenText(JsonFileName))
            {
                return System.Text.Json.JsonSerializer.Deserialize<IList<FoodModel>>(jsonFileReader.ReadToEnd(), new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                    WriteIndented = true
                });
            }
        }

        /// <summary>
        /// Adds a food into list of food
        /// </summary>
        /// <param name="food">Food to add</param>
        public void AddFood(FoodModel food)
        {
            // get food list, even if it's empty it has parent class
            var foodList = GetFood();
            // adds a new food
            foodList.Add(food);

            // write all food into a json file
            using (var outputStream = File.OpenWrite(JsonFileName))
            {
                System.Text.Json.JsonSerializer.Serialize<IEnumerable<FoodModel>>(new Utf8JsonWriter(outputStream, new JsonWriterOptions
                {
                    Indented = true
                }),
                foodList);
            }
        }
    }
}
