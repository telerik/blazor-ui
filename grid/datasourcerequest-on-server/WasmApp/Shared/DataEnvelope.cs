using System;
using System.Collections.Generic;
using System.Text;

namespace WasmApp.Shared
{
    /// <summary>
    /// An evenlope for the DataSourceResult serialization back to the client.
    /// Needed because the framework cannot otherwise serialize the IEnumerable collection
    /// that the Telerik DataSource package produces - it requires an explicit type.
    /// </summary>
    /// <typeparam name="T">The model type that is sent from the server</typeparam>
    public class DataEnvelope<T>
    {
        public List<T> CurrentPageData { get; set; }
        public int TotalItemCount { get; set; }
    }
}
