using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace Data.Entities
{
    [BsonDiscriminator(RootClass = true)]
    [BsonKnownTypes(typeof(Label), typeof(UList), typeof(Image), typeof(Sound), typeof(SourceCode))]
    public abstract class ControlDO
    {
        
    }

    public class Label : ControlDO
    {
        public string Text { get; set; }
    }

    public class UList : ControlDO
    {
        public IEnumerable<string> Elements { get; set;  }
    }

    public class Image : ControlDO
    {
        public string ImagePath { get; set; }
    }

    public class Sound : ControlDO
    {
        public string SoundPath { get; set; }
    }

    public class SourceCode : ControlDO
    {
        public string Language { get; set; }
        public string Code { get; set; }
    }

}