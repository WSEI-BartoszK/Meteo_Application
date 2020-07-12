using System.Text.Json.Serialization;

namespace Meteo_App_Library
{
    public class WeatherForecast
    {
        public int IsSuccess { get; set; }
        public string ErrorMessage { get; set; }

        public string RequestUrl { get; set; }

        [JsonPropertyName("id_stacji")]
        public string WSID { get; set; }
        [JsonPropertyName("stacja")]
        public string CityName { get; set; }
        [JsonPropertyName("data_pomiaru")]
        public string Date { get; set; }
        [JsonPropertyName("godzina_pomiaru")]
        public string Hour { get; set; }
        [JsonPropertyName("temperatura")]
        public string Temperature { get; set; }
        [JsonPropertyName("predkosc_wiatru")]
        public string WindSpeed { get; set; }
        [JsonPropertyName("kierunek_wiatru")]
        public string WindDir { get; set; }
        [JsonPropertyName("wilgotnosc_wzgledna")]
        public string Humidity { get; set; }
        [JsonPropertyName("suma_opadu")]
        public string Rainfall { get; set; }
        [JsonPropertyName("cisnienie")]
        public string Pressure { get; set; }
    }
}
