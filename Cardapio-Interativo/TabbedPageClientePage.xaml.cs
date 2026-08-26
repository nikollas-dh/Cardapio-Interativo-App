using Cardapio_Interativo.Pages;

namespace Cardapio_Interativo;

public partial class TabbedPageClientePage : TabbedPage
{
	public TabbedPageClientePage(Models.Usuario? usLogado)
	{
		InitializeComponent();
        Children.Clear();

        Children.Add(new TelaPrincipalCL(usLogado));
        Children.Add(new Ranking());
    }
}