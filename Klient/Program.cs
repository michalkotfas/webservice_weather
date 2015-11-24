using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//http://www.webservicex.net/globalweather.asmx

namespace Klient
{
    class Program
    {
        static void Main(string[] args)
        {
            string country = "Poland";
            string city = "Gdansk";
            
            GlobalWeather.GlobalWeatherSoapClient serwis = new GlobalWeather.GlobalWeatherSoapClient("GlobalWeatherSoap12");
            serwis.Open();
            
            var result = serwis.GetWeather(city, country);
            
            var start = result.IndexOf("<Temperature>") + "</Temperature>".Length;
            var stop = result.IndexOf("</Temperature>", start);
            var temp = result.Substring(start, stop - start);
            
            Console.WriteLine("Temperatura w " + city + " to " + temp);
            serwis.Close();
            Console.ReadKey();
        }
    }
}
