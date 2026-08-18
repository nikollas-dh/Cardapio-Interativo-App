using Cardapio_Interativo.Models;
using System.Net.Http.Json;

namespace Cardapio_Interativo.Pages;

public partial class Ranking : ContentPage
{
    private readonly HttpClient client = new HttpClient();
    private List<PratoRanking> pratosCurtidos;
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
            //string api = "http://192.168.15.4:5123/api/curtidas";
            string api = "http://10.0.2.2:5123/api/curtidas";
            var json = await client.GetFromJsonAsync<List<PratoRanking>>(api);
            pratosCurtidos = json;
            listaRanking.ItemsSource = pratosCurtidos;
        }
        catch (Exception ex) 
        {
            await DisplayAlert("Erro", ex.Message, "Ok");
        }
    }
}