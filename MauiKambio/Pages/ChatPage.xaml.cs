using ClassLibraryModels.DTOs;
using System.Collections.ObjectModel;

namespace MauiKambio.Pages;

public partial class ChatPage : ContentPage
{
	public ObservableCollection<ChatMessage> Messages { get; set; } = new();

    public ChatPage()
	{
		InitializeComponent();
	}

	private async void SendMessage(object sender, EventArgs e)
    {
		if (string.IsNullOrWhiteSpace(EditorMessage.Text))
		{
			await DisplayAlert("Error", "No hay Mensaje para Enviar", "Ok");
		}


	}
}