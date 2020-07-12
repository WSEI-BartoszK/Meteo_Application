using System.Text.Json.Serialization;

namespace Meteo_App_Library
{
    /*
     
        Basic weather forecast structure
     
     */
    public class WeatherForecast
    {
        /// <summary>
        /// check if request ended with success
        /// </summary>
        public int IsSuccess { get; set; }
        /// <summary>
        /// if is error, heres the error message
        /// </summary>
        public string ErrorMessage { get; set; }
        /// <summary>
        /// URL informatinon, where the request was submitted
        /// </summary>
        public string RequestUrl { get; set; }
        /// <summary>
        /// weather station ID
        /// </summary>
        [JsonPropertyName("id_stacji")]
        public string WSID { get; set; }
        /// <summary>
        /// weathere station city name
        /// </summary>
        [JsonPropertyName("stacja")]
        public string CityName { get; set; }
        /// <summary>
        /// Date wheen the mesurement was teken
        /// </summary>
        [JsonPropertyName("data_pomiaru")]
        public string Date { get; set; }
        /// <summary>
        /// Hour wheen the mesurement was teken
        /// </summary>
        [JsonPropertyName("godzina_pomiaru")]
        public string Hour { get; set; }
        /// <summary>
        /// temperature information
        /// </summary>
        [JsonPropertyName("temperatura")]
        public string Temperature { get; set; }
        /// <summary>
        /// wind speed information
        /// </summary>
        [JsonPropertyName("predkosc_wiatru")]
        public string WindSpeed { get; set; }
        /// <summary>
        /// Wind direction information
        /// </summary>
        [JsonPropertyName("kierunek_wiatru")]
        public string WindDir { get; set; }
        /// <summary>
        /// Humidity information
        /// </summary>
        [JsonPropertyName("wilgotnosc_wzgledna")]
        public string Humidity { get; set; }
        /// <summary>
        /// Rain Fall information
        /// </summary>
        [JsonPropertyName("suma_opadu")]
        public string Rainfall { get; set; }
        /// <summary>
        /// Presure information
        /// </summary>
        [JsonPropertyName("cisnienie")]
        public string Pressure { get; set; }
    }
}
