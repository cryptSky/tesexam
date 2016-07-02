using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Data.Entities;
using Newtonsoft.Json.Linq;

namespace Data.Infrastructure.JsonNET
{
    public class UserAnswerConverter : JsonConverter
    {
        private string _typeQualifier = "Data.Entities.";
        public override bool CanConvert(Type objectType)
        {
            return typeof(UserAnswerDO).IsAssignableFrom(objectType);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var jsonObject = JObject.Load(reader);
            
            var child = jsonObject.Children<JProperty>().First();

            var name = child.Name;
            var typeName = _typeQualifier + char.ToUpper(name[0]) + ((name.Length > 1) ? name.Substring(1) : string.Empty);

            var type = Type.GetType(typeName);
            var valueReader = child.Value.CreateReader();

            var instance = Activator.CreateInstance(type);
            serializer.Populate(valueReader, instance);

            return instance;

        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteStartObject();
            var typeName = value.GetType().Name;
            var propName = char.ToLower(typeName[0]) + ((typeName.Length > 1) ? typeName.Substring(1) : string.Empty);
            
            writer.WritePropertyName(propName);
            writer.WriteRawValue(JsonConvert.SerializeObject(value));
            writer.WriteEndObject();
        }
    }
}
