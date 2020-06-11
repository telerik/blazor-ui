using System;
using System.Collections.Generic;
using System.Text;

namespace CustomSerializer.Shared
{
    /// <summary>
    /// An evenlope for the DataSourceResult serialization back to the client.
    /// Needed because the framework cannot otherwise deserialize the IEnumerable collection
    /// that the Telerik DataSource package produces - it requires an explicit type -
	/// System.Text.Json cannot successfully deserialize interface properties.
    /// It seems and Newtonsoft.Json fails at this as well
    /// </summary>
    /// <typeparam name="T">The model type that is sent from the server</typeparam>
    public class DataEnvelope<T>
    {
        public List<T> CurrentPageData { get; set; }
        public int TotalItemCount { get; set; }
    }
}
