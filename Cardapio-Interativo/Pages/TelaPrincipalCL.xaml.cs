using Cardapio_Interativo.Models;
using System.Net.Http.Json;
using System.Net.WebSockets;

namespace Cardapio_Interativo.Pages;

public partial class TelaPrincipalCL : ContentPage
{
    private static readonly HttpClient client = new HttpClient();
    private List<Restaurante> restaurantesOriginais = new();
	public TelaPrincipalCL()
	{
		InitializeComponent();
		//CarregarDadosRestaurante();
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
            //var api = "http://192.168.15.4:5123/api/restaurante";
            var api = "http://10.0.2.2:5123/api/restaurante";
            var restaurantes = await client.GetFromJsonAsync<List<Restaurante>>(api);

            restaurantesOriginais = restaurantes;
            ListaRestaurantes.ItemsSource = restaurantesOriginais;
        }
        catch (Exception ex)
        {
            await DisplayAlert("Erro na API", ex.Message, "OK");
        }
    }

    private void VisualizarCardapio_Clicked(object sender, EventArgs e)
    {
        var botao = (Button)sender;
        var restaurante = (Restaurante)botao.BindingContext;
        Navigation.PushAsync(new VisualizarCardapio(restaurante.Id));
    }

    private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
    {
        var pesquisa = e.NewTextValue ?? "";

        ListaRestaurantes.ItemsSource = restaurantesOriginais.Where(r=>r.Nome.Contains(pesquisa)).ToList();
    }
}