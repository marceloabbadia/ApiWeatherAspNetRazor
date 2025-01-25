using Api.Models;

namespace Api.Services
{
    public interface IWeatherService
    {
        Task<Weather> GetWeatherAsync(string city);
    }
}
