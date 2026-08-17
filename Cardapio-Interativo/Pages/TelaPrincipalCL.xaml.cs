using Cardapio_Interativo.Models;
using System.Net.Http.Json;

namespace Cardapio_Interativo.Pages;

public partial class TelaPrincipalCL : ContentPage
{
    private static readonly HttpClient client = new HttpClient();
	public TelaPrincipalCL()
	{
		InitializeComponent();
		CarregarDadosRestaurante();
	}


    protected override void OnAppearing()
    {
        base.OnAppearing();
        CarregarDadosRestaurante();

    }
    private async void CarregarDadosRestaurante()
    {

        try
        {
            var api = "http://192.168.15.4:5123/api/restaurante";
            //var api = "http://10.0.2.2:5123/api/restaurante";
            var restaurantes = await client.GetFromJsonAsync<List<Restaurante>>(api);
            ListaRestaurantes.ItemsSource = restaurantes;          
        }
        catch (Exception ex)
        {
            await DisplayAlert("Erro na API", ex.Message, "OK");
        }
    }

    private void VisualizarCardapio_Clicked(object sender, EventArgs e)
    {

    }
}