using System.Diagnostics;
using MauiAppWebServiceSQLite.Models;
using MauiAppWebServiceSQLite.Service;
using MauiAppWebServiceSQLite.Helpers;
using System.Collections.ObjectModel;

namespace MauiAppWebServiceSQLite
{
    public partial class MainPage : ContentPage
    {
        CancellationTokenSource _cancelTokenSource;
        bool _isCheckingLocation;
        string? cidade;

        ObservableCollection<Tempo> _previsoesList = new ObservableCollection<Tempo>();

        public MainPage()
        {
            InitializeComponent();
        }

        /*
           -    Metodo para caputarar campo input cidade.
        */

        private async void Button_Clicked(object sender, EventArgs e)
        {
            string cidade = inputCidade.Text;

            try
            {
                BuscarPrevisao(cidade);
            }
            catch (Exception ex) { 
            
            }
        }

        public async void BuscarPrevisao(string cidade)
        {
            try
            {
                if (!String.IsNullOrEmpty(cidade))
                {
                    Tempo? previsao = await DataService.BucarPrevisao(cidade);
                    DateTime data_atual = DateTime.Now;
                   
                    string dados_previsao = "";

                    if (previsao != null)
                    {
                        SalvarPrevisao(previsao);
                        dados_previsao = $"Humidade: {previsao.Humidity} \n" +
                                         $"Nascer do Sol: {previsao.Sunrise} \n" +
                                         $"Pôr do Sol: {previsao.Sunset} \n" +
                                         $"Temperatura: {previsao.Temperature} \n" +
                                         $"Titulo: {previsao.Title} \n" +
                                         $"Visibilidade: {previsao.Visibility} \n" +
                                         $"Vento: {previsao.Wind} \n" +
                                         $"Previsão: {previsao.Weather} \n" +
                                         $"Descrição: {previsao.WeatherDescription} \n";
                    }
                    else {
                        dados_previsao = $"Sem dados, previsão nula.";
                    }

                    lbl_previsao.Text = dados_previsao;
                }
            }
            catch (Exception ex)
            {

            }
        }


        public async void SalvarPrevisao(Tempo? previsao)
        {
            DateTime data_atual = DateTime.Now;
            Tempo? tempo = new Tempo();

            tempo.Title = previsao.Title;
            tempo.Temperature = previsao.Temperature;
            tempo.Wind = previsao.Wind;
            tempo.Humidity = previsao.Humidity;
            tempo.Visibility = previsao.Visibility;
            tempo.Sunrise = previsao.Sunrise;
            tempo.Sunset = previsao.Sunset;
            tempo.Weather = previsao.Weather;
            tempo.WeatherDescription = previsao.WeatherDescription;
            tempo.srcDate = data_atual;

            await App.Database.Insert(tempo);
            await DisplayAlert("Sucesso!", "Previsão inserido com sucesso", "OK");

        }

        private async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Views.ListaPrevisoes());
        }
    }

}
