namespace BlazorFinancialDashboard.Services
{
    public class NotificationService
    {
        public IReadOnlyList<AppNotification> Items { get; } =
        [
            new("Dividend received", "Northstar Utilities paid a $42.18 dividend to your investment account.", "Today, 9:15 AM"),
            new("Price alert triggered", "Solar Flux reached your target price of $48.00.", "Today, 8:40 AM"),
            new("Transfer scheduled", "A $750.00 transfer to your brokerage account is scheduled for Aug 28.", "Yesterday")
        ];

        public int UnreadCount => Items.Count(item => !item.IsRead);

        public event Action? Changed;

        public void MarkAllRead()
        {
            foreach (var item in Items)
            {
                item.IsRead = true;
            }

            Changed?.Invoke();
        }
    }

    public sealed record AppNotification(string Title, string Message, string When)
    {
        public bool IsRead { get; set; }
    }
}
