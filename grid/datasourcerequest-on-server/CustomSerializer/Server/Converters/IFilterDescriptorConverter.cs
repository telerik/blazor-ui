using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using Telerik.DataSource;

namespace CustomSerializer.Server.JsonConverters
{ 
    public class FilterDescriptorJsonConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(IFilterDescriptor);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject filterDescriptor = JObject.Load(reader);

            return filterDescriptor.ToObject<FilterDescriptor>(serializer);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, (FilterDescriptor)value);
        }
    }
}
