namespace BlazorFinancialDashboard.Data
{
    public class NavItem
    {
        public string Text { get; set; } = string.Empty;
        public object? Icon { get; set; }

        public bool Separator { get; set; }
        public string Url { get; set; } = string.Empty;

        public NavItem(string text, object? icon, string url)
        {
            Text = text;
            Icon = icon;
            Url = url;
        }

        public NavItem()
        {
            Separator = true;
        }
    }
}
