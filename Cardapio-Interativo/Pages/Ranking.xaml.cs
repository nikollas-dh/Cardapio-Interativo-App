using Cardapio_Interativo.Models;
using System.Net.Http.Json;

namespace Cardapio_Interativo.Pages;

public partial class Ranking : ContentPage
{
    private readonly HttpClient client = new HttpClient();
	public Ranking()
	{
		InitializeComponent();
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
        CarregarRanking();
    }

    private async void CarregarRanking()
    {
        try
        {
            var api = "http://10.0.2.2:5123/api/curtidas";
            listaRanking.ItemsSource = await client.GetFromJsonAsync<List<PratoRanking>>(api);
        }        
        catch (Exception ex) 
        {
            await DisplayAlert("Erro", ex.Message, "Ok");
        }
    }
}