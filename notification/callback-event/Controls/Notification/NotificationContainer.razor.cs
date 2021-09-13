using Microsoft.AspNetCore.Components;
using Telerik.Blazor.Components;

namespace Demo.Notification.Controls.Notification
{
    public partial class NotificationContainer
    {
        #region Services

        [Inject] public NotificationService NotificationService { get; set; }

        #endregion Services

        protected override void OnInitialized()
        {
            NotificationService.OnShowNotification += (NotificationModel notificationModel) =>
            {
                InvokeAsync(() =>
                {
                    Message = notificationModel.Text;

                    _notification.Show(notificationModel);
                    StateHasChanged();
                });
            };
        }

        private MarkupString RawText(string text)
        {
            return new MarkupString(text);
        }

        #region Properties

        public string Message { get; set; }

        private TelerikNotification _notification { get; set; }

        #endregion Properties
    }
}
