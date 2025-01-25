using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
namespace Api.Pages
{
    public class CityModel : PageModel
    {
        private readonly IWeatherService _weatherService;

        // Propriedade que vai armazenar o nome da cidade
        public string City { get; set; }

        // Propriedade que vai armazenar as informa��es do clima da cidade
        public Weather WeatherInfo { get; set; }

        //injecao de dependencia, tipo criar a instancia....
        public CityModel(IWeatherService weatherService)
        {
            _weatherService = weatherService;
        }

        // M�todo que ser� chamado ao acessar a p�gina City
        public async Task OnGetAsync(string city)
        {
            if (!string.IsNullOrEmpty(city))
            {
                WeatherInfo = await _weatherService.GetWeatherAsync(city);
            }
        }

    }
}

