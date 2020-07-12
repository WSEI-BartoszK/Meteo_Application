using System;
using System.Collections.Generic;
using System.Net;
using System.Text.Json;

namespace Meteo_App_Library
{
    class Meteo
    {
        // based on https://danepubliczne.imgw.pl/
        // sample usage: https://danepubliczne.imgw.pl/api/data/synop/station/krakow
        private const string BaseUrl = "https://danepubliczne.imgw.pl/api/data/synop/station/";
        private const string AllCitiesURL = "https://danepubliczne.imgw.pl/api/data/synop";

        public static string UrlCreator(string city_name)
        {
            // api is case sensitive city name needs to be lower case
            return BaseUrl + WebUtility.UrlEncode(city_name.ToLower()) + "/";
        }

        public static WeatherForecast GetData(string city_name)
        {
            WeatherForecast wc = new WeatherForecast()
            {
                IsSuccess = 0,
            };

            var requestUrl = UrlCreator(city_name);

            using (var client = new WebClient())
            {
                try
                {
                    var data = client.DownloadData(requestUrl);
                    // Collect data and deserialize it from JSON to WeatherForecast object
                    wc = JsonSerializer.Deserialize<WeatherForecast>(data);
                    wc.IsSuccess = 1;
                }
                catch (WebException ex)
                {
                    // webclient exceptions handling
                    wc.ErrorMessage = ex.Message.ToString();
                }
                catch (Exception ex)
                {
                    // general exception handler
                    wc.ErrorMessage = ex.Message.ToString();
                }
            }

            wc.RequestUrl = requestUrl;

            return wc;
        }

        public static List<WeatherForecast> GetAllCities()
        {
            List<WeatherForecast> allCities = new List<WeatherForecast>();

            using (var client = new WebClient())
            {
                try
                {
                    var data = client.DownloadData(AllCitiesURL);
                    // Collect data and deserialize it from JSON to WeatherForecast object
                    allCities = JsonSerializer.Deserialize<List<WeatherForecast>>(data);

                }
                catch (WebException ex)
                {
                    // webclient exceptions handling
                    Console.WriteLine(ex.Message.ToString());
                }
                catch (Exception ex)
                {
                    // general exception handler
                    Console.WriteLine(ex.Message.ToString());
                }
            }

            return allCities;
        }
    }
}