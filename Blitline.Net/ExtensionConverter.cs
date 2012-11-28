using System;
using Newtonsoft.Json;

namespace Blitline.Net
{
    public class ExtensionConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var v = string.Format(".{0}", value.ToString().ToLowerInvariant());
            writer.WriteValue(v);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Extension);
        }
    }
}