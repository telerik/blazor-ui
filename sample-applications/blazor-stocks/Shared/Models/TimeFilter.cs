using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorFinancePortfolio.Models
{
    public class TimeFilter
    {
        public string Name { get; set; }
        public long Duration { get; set; }

        private static int MS_PER_DAY = 86400000;

        public static List<TimeFilter> GetFilters()
        {
            return new List<TimeFilter>()
                {
                   new TimeFilter { Name = "1H", Duration = MS_PER_DAY / 24 },
                   new TimeFilter { Name = "4H", Duration = MS_PER_DAY / 6 },
                   new TimeFilter { Name = "12H",Duration = MS_PER_DAY / 2 },
                   new TimeFilter { Name = "1D", Duration = MS_PER_DAY },
                   new TimeFilter { Name = "4D", Duration = MS_PER_DAY * 4 },
                   new TimeFilter { Name = "1W", Duration = MS_PER_DAY * 7 }
                };
        }
    }
}
