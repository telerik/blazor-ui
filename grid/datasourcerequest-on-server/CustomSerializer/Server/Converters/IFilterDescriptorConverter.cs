using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using Telerik.DataSource;

namespace CustomSerializer.Server.JsonConverters
{ 
    /// <summary>
    /// Handles serialization and deserialization of the Telerik DataSourceRequest filter descriptors for Newtonsoft.Json
    /// </summary>
    public class FilterDescriptorJsonConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(IFilterDescriptor);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject filterDescriptor = JObject.Load(reader);

            if (filterDescriptor.ContainsKey("logicalOperator"))
            {
                return filterDescriptor.ToObject<CompositeFilterDescriptor>(serializer);
            }
            else
            {
                return filterDescriptor.ToObject<FilterDescriptor>(serializer);
            }
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value is CompositeFilterDescriptor)
            {
                serializer.Serialize(writer, (CompositeFilterDescriptor)value);
            }
            else if (value is FilterDescriptor)
            {
                serializer.Serialize(writer, (FilterDescriptor)value);
            }
        }
    }
}
