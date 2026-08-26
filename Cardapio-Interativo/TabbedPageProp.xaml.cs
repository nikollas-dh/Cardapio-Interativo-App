using Cardapio_Interativo.Pages;

namespace Cardapio_Interativo;

public partial class TabbedPageProp : TabbedPage
{
	public TabbedPageProp(Models.Usuario usLogado)
	{
		InitializeComponent();
		Children.Clear();

		Children.Add(new TelaPrincipalPR(usLogado));
		Children.Add(new PratosProprietarioPage(usLogado));
		Children.Add(new Ranking());
	}
}