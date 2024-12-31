using System;

namespace TelerikBlazorServerDashboard.Models
{
    public partial class PodcastViewModel
    {
        private int views;

        public string Name { get; set; } = string.Empty;

        public int Downloads { get; set; }

        public int Streams { get; set; }

        public int Views
        {
            get
            {
                return Downloads + Streams;
            }
            private set
            {
                views = value;
            }
        }

        public DateTime Date { get; set; }

        public int Reach { get; set; }

        public string Device { get; set; } = string.Empty;

        public string PlatformName { get; set; } = string.Empty;
    }
}
