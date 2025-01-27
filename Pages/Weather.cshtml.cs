
namespace Api.Pages
{
    public class WeatherModel : PageModel
    {
        private readonly IWeatherService _weatherService;

        public List<string> Cities = new List<string>
    {
        "New York",
        "Tokyo",
        "Paris",
        "London",
        "Brasília",
        "Abu Dhabi",
        "Canberra",
        "Cape Town",
        "Berlin",
        "Bangkok"
    };


        public WeatherModel(IWeatherService weatherService)
        {
            _weatherService = weatherService;
        }


        public void OnGet(List<string> cities)
        {
            var Cities = cities;
        }
    }
}