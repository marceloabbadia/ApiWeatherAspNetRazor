namespace Api.Models
{
    public class WeatherApiResponse
    {

        public Request Request { get; set; }
        public Location Location { get; set; }
        public Current Current { get; set; }
    }

    public class Request
    {
        public string Type { get; set; }
        public string Query { get; set; }
        public string Language { get; set; }
        public string Unit { get; set; }
    }

    public class Location
    {
        public string Name { get; set; }
        public string Country { get; set; }
        public string Region { get; set; }
        public string Lat { get; set; }  
        public string Lon { get; set; }  
        public string TimezoneId { get; set; }
        public string Localtime { get; set; }
    }


    public class Current
    {
        public string ObservationTime { get; set; }
        public double Temperature { get; set; }
        public int WeatherCode { get; set; }
        public List<string> weather_descriptions { get; set; }
        public List<string> WeatherIcons { get; set; }
        public double WindSpeed { get; set; }
        public int WindDegree { get; set; }
        public string WindDir { get; set; }
        public double Pressure { get; set; }
        public double Precip { get; set; }
        public int Humidity { get; set; }
        public int Cloudcover { get; set; }
        public double FeelsLike { get; set; }
        public int UvIndex { get; set; }
        public double Visibility { get; set; }
    }

}
