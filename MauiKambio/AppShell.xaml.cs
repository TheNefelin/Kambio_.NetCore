using MauiKambio.Pages;

namespace MauiKambio
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            this.Navigating += OnNavigating;
        }

        private async void OnNavigating(object sender, ShellNavigatingEventArgs e)
        {
            // Si cambias de una pestaña a otra
            if (e.Source == ShellNavigationSource.ShellSectionChanged)
            {
                // Cerrar todos los modales abiertos
                while (App.Current.MainPage.Navigation.ModalStack.Count > 0)
                {
                    await App.Current.MainPage.Navigation.PopModalAsync(false);
                }

                // Luego, limpiar el stack de navegación de la pestaña actual
                await Current.Navigation.PopToRootAsync(false);
            }
        }

        private void OnLogoutClicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new LoginPage();
        }
    }
}
