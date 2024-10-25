namespace MauiKambio.Pages;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();
	}

	private async void OnLoginApple(object sender, EventArgs e)
    {
		App.Current.MainPage = new AppShell();
    }

	private async void OnLoginGmail(object sender, EventArgs e)
	{
        App.Current.MainPage = new AppShell();
    }
}