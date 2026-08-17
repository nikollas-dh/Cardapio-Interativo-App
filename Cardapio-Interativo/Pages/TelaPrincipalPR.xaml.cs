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
       
    }
    private void btnLogin_Clicked(object sender, EventArgs e)
    {

    }
}