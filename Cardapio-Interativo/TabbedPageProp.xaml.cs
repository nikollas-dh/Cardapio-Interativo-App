using Cardapio_Interativo.Pages;

namespace Cardapio_Interativo;

public partial class TabbedPageProp : TabbedPage
{
	public TabbedPageProp()
	{
		InitializeComponent();
		Children.Clear();

		Children.Add(new TelaPrincipalPR());
		Children.Add(new PratosProprietarioPage());
		Children.Add(new Ranking());
	}
}