using MauiKambio.Pages;

namespace MauiKambio
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
        }

        private void OnLogoutClicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new LoginPage();
        }
    }
}
