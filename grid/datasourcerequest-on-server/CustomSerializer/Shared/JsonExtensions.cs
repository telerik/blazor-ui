using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace CustomSerializer.Shared
{
    public static class JsonExtensions
    {
        /// <summary>
        /// Tries to deserialize an object serialized to JSON accoring to its type. 
        /// Custom Extension method used to deserialize grouped data descriptors in this project.
        /// </summary>
        /// <typeparam name="T">Type to deserialize to</typeparam>
        /// <param name="element">The serialized object</param>
        /// <param name="options">Deserialization options. In the project this originates from - usually case-insensitive</param>
        /// <returns></returns>
        public static object Deserialize<T>(this JsonElement element, JsonSerializerOptions options = null)
        {
            return JsonSerializer.Deserialize(element.GetRawText(), typeof(T), options);
        }
    }
}
