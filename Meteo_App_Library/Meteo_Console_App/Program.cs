using Meteo_App_Library;
using System;
using System.Collections.Generic;

namespace Meteo_Console_App
{
    class Program
    {
        #region menu
        static void MenuItems()
        {
            Spacer();
            Console.WriteLine("Pozycję w menu: ");
            Console.WriteLine(" ");
            Console.WriteLine("1: Sprawdź pogodę (https://danepubliczne.imgw.pl/)");
            Console.WriteLine("2: Lista dostępnych miast");
            Console.WriteLine("3: O autorze");
            Console.WriteLine("4: Zakończ Aplikacje");
            Spacer();
        }
        static void Spacer()
        {
            Console.WriteLine(" ");
            Console.WriteLine("---------------------");
            Console.WriteLine(" ");
        }

        static void CreatedBy()
        {
            Spacer();
            Console.WriteLine("Bartosz Kapusta");
            Console.WriteLine("Grupa lab8/1/IEN");
            Console.WriteLine("Index 12494");
            Spacer();
        }
        static void MenuGetAllCities()
        {
            Console.Clear();
            Spacer();
            List<WeatherForecast> cities = Meteo.GetAllCities();

            foreach (WeatherForecast city in cities)
            {
                Console.WriteLine("Miasto: " + city.CityName);
            }

            Spacer();
        }
        static void Anykey()
        {
            Console.Write("Naciśni dowolny klawisz by wrócić do Menu.");
            Console.ReadKey();
            Spacer();
        }
        #endregion

        #region MeteoResponse
        static void MeteoResponse(WeatherForecast weatherForecast)
        {
            Console.WriteLine(" ");
            if (weatherForecast.IsSuccess == 1)
            {
                Console.WriteLine("Request URL: " + weatherForecast.RequestUrl);
                Console.WriteLine("id_stacji: " + weatherForecast.WSID);
                Console.WriteLine("stacja: " + weatherForecast.CityName);
                Console.WriteLine("data_pomiaru: " + weatherForecast.Date);
                Console.WriteLine("godzina_pomiaru: " + weatherForecast.Hour);
                Console.WriteLine("temperatura: " + weatherForecast.Temperature);
                Console.WriteLine("predkosc_wiatru: " + weatherForecast.WindSpeed);
                Console.WriteLine("kierunek_wiatru: " + weatherForecast.WindDir);
                Console.WriteLine("wilgotnosc_wzgledna: " + weatherForecast.Humidity);
                Console.WriteLine("suma_opadu: " + weatherForecast.Rainfall);
                Console.WriteLine("cisnienie: " + weatherForecast.Pressure);
            }
            else if (weatherForecast.IsSuccess == 0)
            {
                Console.WriteLine("[!] error:" + weatherForecast.ErrorMessage);
                Console.WriteLine("Sprawdź czy miasto jest na liście - Menu [2].");
                Console.WriteLine("Lub sprwadź czy podałeś nazwę miasta poprawnie: bez spacji i polskich znaków.");
            }
            else
            {
                Console.WriteLine("[!] Unknown Error" + weatherForecast.ErrorMessage);
            }
            Spacer();
        }
        #endregion
        static void Main(string[] args)
        {
            #region user input
            int userInput;
            string userChoice;
            string city_name;
            #endregion

            do
            {
                MenuItems();

                Console.Write("Wybierz pozycję z menu [1-4]: ");
                userChoice = Console.ReadLine();

                // check if is number
                if (!Int32.TryParse(userChoice, out userInput)) continue;

                if (userChoice == "4")
                {
                    Environment.Exit(0);
                }

                if (userChoice == "3")
                {
                    CreatedBy();
                }

                if (userChoice == "2")
                {
                    MenuGetAllCities();
                }

                if (userChoice == "1")
                {
                    Console.Clear();
                    Spacer();
                    Console.Write("Podaj nazwę miasta bez spacji i polskich znaków [np. ZielonaGora]: ");
                    city_name = Console.ReadLine();

                    MeteoResponse(Meteo.GetData(city_name));


                }
                Anykey();
            }
            while (true);
        }
    }
}
