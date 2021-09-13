using System;
using Telerik.Blazor;
using Telerik.Blazor.Components;

namespace Demo.Notification.Controls.Notification
{
    public class NotificationService
    {
        public void Error(string msg, int closeAfter = 5000)
        {
            OnShowNotification?.Invoke(new NotificationModel
            {
                Text = msg,
                ThemeColor = ThemeColors.Error,
                Icon = "x-outline",
                CloseAfter = closeAfter
            });
        }

        public void Info(string msg, int closeAfter = 5000)
        {
            OnShowNotification?.Invoke(new NotificationModel
            {
                Text = msg,
                ThemeColor = ThemeColors.Info,
                Icon = "info-circle",
                CloseAfter = closeAfter
            });
        }

        public event Action<NotificationModel> OnShowNotification;

        public void Success(string msg, int closeAfter = 5000)
        {
            OnShowNotification?.Invoke(new NotificationModel
            {
                Text = msg,
                ThemeColor = ThemeColors.Success,
                Icon = "check-outline",
                CloseAfter = closeAfter
            });
        }

        public void Warning(string msg, int closeAfter = 5000)
        {
            OnShowNotification?.Invoke(new NotificationModel
            {
                Text = msg,
                ThemeColor = ThemeColors.Warning,
                Icon = "exclamation-circle",
                CloseAfter = closeAfter
            });
        }
    }
}