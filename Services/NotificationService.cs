using System;

namespace VpnClient.Services
{
    public class NotificationService
    {
        public void ShowNotification(string title, string message)
        {
            // In a real WPF app, you would use a library like ToastNotifications or Windows.UI.Notifications
            // For this MVP, we'll just simulate it with a console output or a simple MessageBox if needed.
            Console.WriteLine($"Notification - {title}: {message}");
            // You could also consider an event to be picked up by the UI for a simple in-app notification display.
        }
    }
}

