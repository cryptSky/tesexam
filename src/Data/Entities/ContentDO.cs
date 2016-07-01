using Data.Entities.Enums;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace Data.Entities
{
    public class ContentDO : Entity
    {
        public IEnumerable<ControlDO> Controls { get; set; }
    }
}