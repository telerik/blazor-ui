using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AddRemoveTiles.Models
{
    public partial class PodcastViewModel
    {
        private int views;

        public string Name { get; set; }

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

        public string Device { get; set; }

        public string PlatformName { get; set; }
    }
}
