using Cardapio_Interativo.Models;
using System.Net.Http.Json;

namespace Cardapio_Interativo.Pages;

public partial class TelaPrincipalPR : ContentPage
{
    private static readonly HttpClient client = new HttpClient();
    private List<Restaurante> restaurantesOriginais = new();
    Usuario us= new Usuario();
    public TelaPrincipalPR(Usuario usLogado)
	{
		InitializeComponent();
        us = usLogado;
	}
    protected override void OnAppearing()
    {
        base.OnAppearing();
        CarregarDadosRestauranteProp();

    }
    private async void CarregarDadosRestauranteProp()
    {
        int id = us.Id;
        try
        {
            var api = $"http://10.0.2.2:5123/api/restaurante/{id}";
            //var api = $"http://192.168.15.4:5123/api/restaurante/{id}";
            //var api = $"http://10.106.69.19:5123/api/restaurante/{id}";
            var restaurantes = await client.GetFromJsonAsync<List<Restaurante>>(api);
            ListaRestaurantes.ItemsSource = restaurantes;

        }
        catch (Exception ex)
        {
            await DisplayAlert("Erro na API", ex.Message, "OK");
        }
    }
    private void Button_Clicked(object sender, EventArgs e)
    {

    }

    private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
    {
        var pesquisa = e.NewTextValue.ToLower() ?? "";

        ListaRestaurantes.ItemsSource = restaurantesOriginais
            .Where(r => r.Nome.Contains(pesquisa, StringComparison.OrdinalIgnoreCase))
            .ToList();
    }
}