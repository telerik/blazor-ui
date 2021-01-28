using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Loccioni.DataSource
{
    public static class GridUrlParameters
    {
        public static string Aggregates
        {
            get;
            set;
        }

        public static string Filter { get; set; }
        public static string Page { get; set; }
        public static string PageSize { get; set; }
        public static string Sort { get; set; }
        public static string Group { get; set; }
        public static string Mode { get; set; }
        public static string GroupPaging { get; set; }
        public static string IncludeSubGroupCount { get; set; }
        public static string Skip { get; set; }
        public static string Take { get; set; }

        static GridUrlParameters()
        {
            Sort = "sort";
            Group = "group";
            Page = "page";
            PageSize = "pageSize";
            Filter = "filter";
            Mode = "mode";
            Aggregates = "aggregate";
            GroupPaging = "groupPaging";
            Skip = "skip";
            Take = "take";
            IncludeSubGroupCount = "includeSubGroupCount";
        }

        public static IDictionary<string, string> ToDictionary(string prefix)
        {
            IDictionary<string, string> result = new Dictionary<string, string>();

            result[Group] = prefix + Group;
            result[Sort] = prefix + Sort;
            result[Page] = prefix + Page;
            result[PageSize] = prefix + PageSize;
            result[Filter] = prefix + Filter;
            result[Mode] = prefix + Mode;
            result[GroupPaging] = prefix + GroupPaging;
            result[Skip] = prefix + Skip;
            result[Take] = prefix + Take;
            result[IncludeSubGroupCount] = prefix + IncludeSubGroupCount;

            return result;
        }
    }

}
