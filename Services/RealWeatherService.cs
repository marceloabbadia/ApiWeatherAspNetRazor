using System.Text.Json;
using RestSharp;

namespace Api.Services
{
    public class RealWeatherService : IWeatherService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        private  string _apiKey = "";
        private  string _baseUrl = "";

        //public RealWeatherService(HttpClient httpClient)
        //{
        //    _httpClient = httpClient;

        //}

        public RealWeatherService(HttpClient httpClient, IConfiguration configuration)
        {
            _baseUrl = configuration.GetValue<string>("WeatherStack:BaseUrl");
            _apiKey = configuration.GetValue<string>("WeatherStack:ApiKey");
            _httpClient = httpClient;
            _configuration = configuration;

        }


       // public async Task<Weather> GetWeatherAsync(string city)
        public Weather GetWeatherAsync(string city)
        {
            var url = $"{_baseUrl}/current?access_key={_apiKey}&query={city}";
            
            var client = new RestClient(url);
            var request = new RestRequest("", Method.Get);

            var response = client.Execute(request);


            // Envia a requisição para a API
            //var response = await _httpClient.GetStringAsync(url);


            // Deserializa a resposta da API
            var weatherResponse = JsonSerializer.Deserialize<WeatherApiResponse>(response.Content, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

 

            var weather = new Weather
            {
                City = weatherResponse?.Location?.Name ?? "Unknown", 
                Country = weatherResponse?.Location?.Country ?? "Unknown", 
                Lat = double.TryParse(weatherResponse?.Location?.Lat, out double lat) ? lat : 0, 
                Lon = double.TryParse(weatherResponse?.Location?.Lon, out double lon) ? lon : 0,
                WeatherDescriptions = weatherResponse?.Current?.weather_descriptions?.FirstOrDefault() ?? "No description", 
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