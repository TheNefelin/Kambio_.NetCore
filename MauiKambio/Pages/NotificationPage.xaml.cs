using ClassLibraryModels.DTOs;
using MauiKambio.Services;
using System.Collections.ObjectModel;

namespace MauiKambio.Pages;

public partial class NotificationPage : ContentPage
{
    private readonly ApiNotificationService _notificationService;
    public ObservableCollection<NotificationDTO> Notifications { get; set; } = new();

    public NotificationPage()
	{
		InitializeComponent();
        _notificationService = new ApiNotificationService();
        BindingContext = this;
        LoadNotification();
    }

    private async void LoadNotification()
    {
        var notifications = _notificationService.GetAll();

        foreach (var notification in notifications)
        {
            Notifications.Add(notification);
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