using ClassLibraryClient.Services;
using ClassLibraryModels.DTOs;
using System.Collections.ObjectModel;

namespace MauiKambio.Pages;

public partial class NotificationPage : ContentPage
{
    private readonly ApiNotificationService _notificationService;
    public ObservableCollection<NotificationDTO> Notifications { get; set; } = new();

    public NotificationPage()
	{
		InitializeComponent();
        BindingContext = this;
        _notificationService = new ApiNotificationService();

        LoadNotification();
    }

    private void LoadNotification()
    {
        try
        {
            var notifications = _notificationService.GetAll();

            Notifications.Clear();
            foreach (var notification in notifications)
            {
                Notifications.Add(notification);
            }
        }
        catch (Exception ex)
        {
            // Manejo de errores para diagnosticar el problema.
            DisplayAlert("Error", $"No se pudieron cargar las notificaciones: {ex.Message}", "OK");
        }
    }

    private async void OnChat(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ChatPage());
    }

    private async void OnDelete(object sender, EventArgs e)
    {
        if (sender is SwipeItem swipeItem && swipeItem.BindingContext is NotificationDTO notification)
        {
            Notifications.Remove(notification);
        }
    }
}