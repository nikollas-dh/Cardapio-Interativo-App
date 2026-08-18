using Cardapio_Interativo.Models;
using System.Net.Http.Json;

namespace Cardapio_Interativo.Pages;

public partial class VisualizarCardapio : ContentPage
{
    int id=0;
    private readonly HttpClient cl = new();
	public VisualizarCardapio(int id)
	{
		InitializeComponent();
        this.id = id;
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
        CarregarDados(id);
    }

    private async void CarregarDados(int id)
    {
        //var api = $"http://10.0.2.2:5123/api/cardapio/{id}";
        //var res = await cl.GetFromJsonAsync<List<CardapioResponse>>(api);

        //listaCardapio.ItemsSource = res;
    }
}