using Data.Entities.Enums;
using Data.Infrastructure.JsonNET;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Data.Entities
{
    [JsonConverter(typeof(ContentConverter))]
    public class ContentDO
    {
        public List<ControlDO> Controls { get; private set; }

        public ContentDO()
        {
            Controls = new List<ControlDO>();
        }

        public void AddControl(ControlDO control)
        {
            Controls.Add(control);
        }
    }
}