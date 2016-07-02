using System;
using Newtonsoft.Json;
using Data.Entities;
using Newtonsoft.Json.Linq;

namespace Data.Infrastructure.JsonNET
{
    public class ContentConverter : JsonConverter
    {
        private string _typeQualifier = "Data.Entities.";
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(ContentDO);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var jsonObject = JObject.Load(reader);
            var instance = (ContentDO)Activator.CreateInstance(objectType);
            
            var controls = jsonObject["controls"] as JObject;
            var childControls = controls.Children<JProperty>();
            foreach (var child in childControls)
            {
                var name = child.Name;
                var typeName = _typeQualifier + char.ToUpper(name[0]) + ((name.Length > 1) ? name.Substring(1).ToLower() : string.Empty);

                var type = Type.GetType(typeName);
                var valueReader = child.Value.CreateReader();

                var cInstance = Activator.CreateInstance(type);
                serializer.Populate(valueReader, cInstance);

                instance.AddControl(cInstance as ControlDO);
            }

            return instance;
            
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var content = (ContentDO)value;
            writer.WriteStartObject();
            writer.WritePropertyName("controls");
            writer.WriteStartObject();
            foreach (var control in content.Controls)
            {
                var name = control.GetType().Name;
                name = char.ToLower(name[0]) + ((name.Length > 1) ? name.Substring(1) : string.Empty);

                writer.WritePropertyName(name);
                writer.WriteRawValue(JsonConvert.SerializeObject(control));                
            }
            writer.WriteEndObject();
            writer.WriteEndObject();
        }
    }
}
