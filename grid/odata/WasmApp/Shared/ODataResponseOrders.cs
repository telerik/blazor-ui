using System;
using System.Collections.Generic;
using System.Text;

namespace WasmApp.Shared
{
    public class ODataResponseOrders
    {
        //this attribute requires that the Shared project has a references to the System.Text.Json NuGet package
        //it is available by default in the client Blazor project in case you define your models there
        [System.Text.Json.Serialization.JsonPropertyName("value")]
        public List<ODataProduct> Products { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("@odata.count")]
        public int Total { get; set; }
    }
}
