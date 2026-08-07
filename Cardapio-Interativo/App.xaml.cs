using Cardapio_Interativo.Pages;
using Microsoft.Extensions.DependencyInjection;

namespace Cardapio_Interativo
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new NavigationPage(new LoginPage()));
        }
    }
}