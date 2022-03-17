namespace NutritionWatcher.Services
{
    /// <summary>
    /// Service for creating greeting depending on time and name
    /// </summary>
    public class GreetingPickerService
    {
        private string TimeGreeting { get; set; }

        /// <summary>
        /// Sets the beginning of the greeting depending on current time
        /// </summary>
        private void SetGreetingFormat()
        {
            // current hour
            int currentHour = DateTime.Today.Hour;

            // set greeting based on time
            if (Enumerable.Range(5, 12).Contains(currentHour))
                TimeGreeting = "Good morning";
            else if (Enumerable.Range(13, 16).Contains(currentHour))
                TimeGreeting = "Good afternoon";
            else
                TimeGreeting = "Good evening";
        }

        /// <summary>
        /// Sets greeting based on current time
        /// </summary>
        /// <param name="Name">User name</param>
        /// <returns></returns>
        public string Greeting(string Name)
        {
            SetGreetingFormat();
            return $"{TimeGreeting}, {Name}";
        }
    }
}
