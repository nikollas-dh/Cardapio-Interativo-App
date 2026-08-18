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

    private void btnLogin_Clicked_1(object sender, EventArgs e)
    {
        Application.Current.MainPage = new TabbedPageClientePage();

    }
}