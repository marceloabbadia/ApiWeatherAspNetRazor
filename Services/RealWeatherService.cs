using System.Text.Json;

namespace Api.Services
{
    public class RealWeatherService : IWeatherService
    {
        private readonly HttpClient _httpClient;

        private const string AccessKey = "a6ee67382bac942359b7932c3cdd500c";

        public RealWeatherService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Weather> GetWeatherAsync(string city)
        {
            var url = $"https://api.weatherstack.com/current?access_key={AccessKey}&query={city}";

            // Envia a requisição para a API
            var response = await _httpClient.GetStringAsync(url);


            // Deserializa a resposta da API
            var weatherResponse = JsonSerializer.Deserialize<WeatherApiResponse>(response, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

 

            var weather = new Weather
            {
                City = weatherResponse?.Location?.Name ?? "Unknown", 
                Country = weatherResponse?.Location?.Country ?? "Unknown", 
                Lat = double.TryParse(weatherResponse?.Location?.Lat, out double lat) ? lat : 0, 
                Lon = double.TryParse(weatherResponse?.Location?.Lon, out double lon) ? lon : 0,
                weather_descriptions = weatherResponse?.Current?.weather_descriptions?.FirstOrDefault() ?? "No description", 
                Temperature = weatherResponse?.Current?.Temperature ?? 0,
                IconUrl = weatherResponse?.Current?.WeatherIcons?.FirstOrDefault() ?? "No icon", 
                WindSpeed = weatherResponse?.Current?.Wind_Speed ?? 0, 
                Pressure = weatherResponse?.Current?.Pressure ?? 0, 
                Humidity = weatherResponse?.Current?.Humidity ?? 0,
                FeelsLike = weatherResponse?.Current?.FeelsLike ?? 0, 
                UvIndex = weatherResponse?.Current?.uv_index ?? 0, 
                Visibility = weatherResponse?.Current?.Visibility ?? 0 
            };


            return weather;
        }

    }
}