using System;
using System.Collections.Generic;
using System.Text;
using Telerik.DataSource;

namespace gRPCsample.Shared
{
    public class DataEnvelope<T>

    {
        /// <summary>
        /// Use this when there is data grouping
        /// </summary>
        public List<AggregateFunctionsGroup> GroupedData { get; set; }

        /// <summary>
        /// Use this when there is no data grouping and the response is flat data, like in the common case.
        /// </summary>
        public List<T> CurrentPageData { get; set; }

        /// <summary>
        /// Always set this to the total number of records.
        /// </summary>
        public int TotalItemCount { get; set; }
    }
}
