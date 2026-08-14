using Cardapio_Interativo.Models;
using System.Net.Http.Json;

namespace Cardapio_Interativo.Pages;

public partial class TelaPrincipalPR : ContentPage
{
	public TelaPrincipalPR()
	{
		InitializeComponent();
	}
    protected override void OnAppearing()
    {
        base.OnAppearing();
        CarregarDadosRestaurante();

    }
    private async void CarregarDadosRestaurante()
    {
        // TESTE 1: Verificar se a função está executando
        await DisplayAlert("Teste", "Iniciando busca na API...", "OK");

        try
        {
            var api = "http://10.106.69.19:5166/api/restaurante";

            // Pega a lista
            var dados = await new HttpClient().GetFromJsonAsync<List<Restaurante>>(api);

            // TESTE 2: Verificar quantos itens retornaram
            if (dados != null)
            {
                await DisplayAlert("Sucesso", $"Chegaram {dados.Count} restaurantes!", "OK");
                Restaurantes.ItemsSource = dados;
            }
            else
            {
                await DisplayAlert("Aviso", "A API retornou uma lista nula.", "OK");
            }
        }
        catch (Exception ex)
        {
            // TESTE 3: Se der erro de conexão/IP/Network
            await DisplayAlert("Erro na API", ex.Message, "OK");
        }
    }
    private void btnLogin_Clicked(object sender, EventArgs e)
    {

    }
}