namespace Cardapio_Interativo.Pages;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();
	}

    private void btnLogin_Clicked(object sender, EventArgs e)
    {
		Application.Current.MainPage = new TabbedPageProp();
    }
}