namespace MauiKambio.Pages;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();
	}

	private async void OnLoginApple(object sender, EventArgs e)
    {
        await PerformLoginAsync();
    }

	private async void OnLoginGmail(object sender, EventArgs e)
	{
		await PerformLoginAsync();
    }

    private async Task PerformLoginAsync()
	{
		await Navigation.PushModalAsync(new LoadingPage());

        App.Current.MainPage = new AppShell();

		await Navigation.PopModalAsync();
    }
}