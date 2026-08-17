using Cardapio_Interativo.Models;
using System.Net.Http.Json;

namespace Cardapio_Interativo.Pages;

public partial class TelaPrincipalPR : ContentPage
{
    private static readonly HttpClient client = new HttpClient();
    private List<Restaurante> restaurantesOriginais = new();
    public TelaPrincipalPR()
	{
		InitializeComponent();
	}
    protected override void OnAppearing()
    {
        base.OnAppearing();
        CarregarDadosRestauranteProp();

    }
    private async void CarregarDadosRestauranteProp()
    {
        int id = 4;
        try
        {
            var api = $"http://192.168.15.4:5123/api/restaurante/{id}";
            //var api = $"http://10.106.69.19:5123/api/restaurante/{id}";
            var restaurantes = await client.GetFromJsonAsync<List<Restaurante>>(api);
            //ListaRestaurantes.ItemsSource = restaurantes;

            if (restaurantes != null)
            {
                restaurantesOriginais = restaurantes;

                ListaRestaurantes.ItemsSource = restaurantesOriginais;
            }
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
        var pesquisa = e.NewTextValue ?? "";

        ListaRestaurantes.ItemsSource = restaurantesOriginais
            .Where(r => r.Nome.Contains(pesquisa, StringComparison.OrdinalIgnoreCase))
            .ToList();
    }
}