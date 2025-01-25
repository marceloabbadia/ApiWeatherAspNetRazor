namespace Api.Models
{
    public class Weather
    {
        public string City { get; set; }
        public string Country { get; set; }
        public double Lat { get; set; }
        public double Lon { get; set; }
        public string weather_descriptions { get; set; }
        public double Temperature { get; set; } 
        public string IconUrl { get; set; }
        public double WindSpeed { get; set; } 
        public double Pressure { get; set; } 
        public double Humidity { get; set; } 
        public double FeelsLike { get; set; } 
        public int UvIndex { get; set; }
        public double Visibility { get; set; } 
    }
}