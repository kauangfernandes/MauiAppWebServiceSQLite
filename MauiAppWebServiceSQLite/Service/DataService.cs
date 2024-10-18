using MauiAppWebServiceSQLite.Models;
using System.Diagnostics;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MauiAppWebServiceSQLite.Service
{
    public class DataService
    {
        /*
            Não sei o por que se eu deixar publico da erro : CS0050
            Removi public antes de static e desapareceu o erro: XD,
            ate o momento nao sei de esta funcionando.
            
            Pelo que li, o compilador esta assumindo que o metodo e internal.
            Germini me sugeriu uma ganbiarra que talves funcione, 
            criar uma funcao publica que chama a privada.
            ----------------------------------------------------------------------------------------------
            18/10/2024 02:08 - Depois de ler mil e uma vez o mesmo erro e chat não me dar um solução
            decobri que... minha class Tempo estava como internal ou seja nunca eu ia conseguir as funções.
        */

        public static async Task<Tempo?> BucarPrevisao(string cidade)
        {

            string appId = "6135072afe7f6cec1537d5cb08a5a1a2";
            string url = $"http://api.openweathermap.org/data/2.5/weather?q={cidade}&units=metric&appid={appId}";

            Tempo? tempo = null;

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode) {

                    string json = response.Content.ReadAsStringAsync().Result;
                    var rascunho = JObject.Parse(json);

                    DateTime time = new DateTime(1970, 1, 1, 0, 0, 0, 0);
                    DateTime sunrise = time.AddSeconds((double)rascunho["sys"]["sunrise"]).ToLocalTime();
                    DateTime sunset = time.AddSeconds((double)rascunho["sys"]["sunset"]).ToLocalTime();

                    tempo = new() {
                        Humidity = (string)rascunho["main"]["humidity"],
                        Temperature = (string)rascunho["main"]["temp"],
                        Title = (string)rascunho["name"],
                        Visibility = (string)rascunho["visibility"],
                        Wind = (string)rascunho["wind"]["speed"],
                        Sunrise = sunrise.ToString(),
                        Sunset = sunset.ToString(),
                        Weather = (string)rascunho["weather"][0]["main"],
                        WeatherDescription = (string)rascunho["weather"][0]["description"],
                    };
                }
            }
            return tempo;
        }
    }
}
