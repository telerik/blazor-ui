using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telerik.Blazor.Components;

namespace OneNotificationPerApp.Data
{
    public class SharedNotification
    {
        private TelerikNotification notification { get; set; }
        public void ShowNotification(NotificationModel model)
        {
            notification?.Show(model);
        }

        public SharedNotification(TelerikNotification instance)
        {
            notification = instance;
        }
    }
}
