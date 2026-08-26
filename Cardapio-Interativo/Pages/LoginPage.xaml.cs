using Cardapio_Interativo.Models;
using System.Text;
using System.Text.Json;

namespace Cardapio_Interativo.Pages;

public partial class LoginPage : ContentPage
{ 
	
	public LoginPage()
	{
		InitializeComponent();
	}

    private async void btnLogin_Clicked(object sender, EventArgs e)
    {
		//Application.Current.MainPage = new TabbedPageProp();

        Usuario usuario = new Usuario();
        usuario.Email = txtEmail.Text;
        usuario.Senha = txtSenha.Text;
		

		
		var client = new HttpClient();
		try
		{
			string api = "http://10.0.2.2:5123/api/usuario/login";
			string json = JsonSerializer.Serialize(usuario);

			var content = new StringContent(json,Encoding.UTF8,"application/json");
			var res = await client.PostAsync(api,content);

			if (res.IsSuccessStatusCode) 
			{
				var	resBody = await res.Content.ReadAsStringAsync();
				var usLogado = JsonSerializer.Deserialize<Usuario>(resBody,new JsonSerializerOptions 
				{
					PropertyNameCaseInsensitive = true
				});


				if (usLogado.PerfilId == 3)
				{
					Application.Current.MainPage = new TabbedPageClientePage(usLogado);
				}
				else
				{
					Application.Current.MainPage = new TabbedPageProp(usLogado);
				}
			}
			else
			{
				await DisplayAlert("Erro", "Email ou senha inválidos", "OK");
			}

		}
		catch (Exception)
		{
			await DisplayAlert("Erro", "Não foi possível conectar com a API","OK");
		}
	}

    private void btnLogin_Clicked_1(object sender, EventArgs e)
    {
		 //Application.Current.MainPage = new TabbedPageClientePage();

    }
}