using System;
using System.Collections.Generic;
using System.Text;

namespace ServerPdfExport.Shared
{
    public class DataEnvelope<T>
    {
        public List<T> CurrentPageData { get; set; }

        public int TotalItemCount { get; set; }
    }
}
