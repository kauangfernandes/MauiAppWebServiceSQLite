namespace MauiAppWebServiceSQLite.Views;
using System.Collections.ObjectModel;
using MauiAppWebServiceSQLite.Models;
using System.Diagnostics;
using MauiAppWebServiceSQLite.Helpers;

public partial class ListaPrevisoes : ContentPage
{
	public ListaPrevisoes()
	{
		InitializeComponent();
        ObservableCollection<Tempo> lista_previsoes = new ObservableCollection<Tempo>();
        lst_previsoes.ItemsSource = lista_previsoes;
    }

    private void txt_src_TextChanged(object sender, TextChangedEventArgs e)
    {

    }
}