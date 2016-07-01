using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace Data.Entities
{
    [BsonDiscriminator(RootClass = true)]
    [BsonKnownTypes(typeof(TextBox), typeof(UnorderedList), typeof(Image), typeof(Sound), typeof(SourceCode))]
    public abstract class ControlDO : Entity
    {
        
    }

    public class TextBox : ControlDO
    {
        public string Text { get; set; }
    }

    public class UnorderedList
    {
        public IEnumerable<string> Elements { get; set;  }
    }

    public class Image : ControlDO
    {
        public string Path { get; set; }
    }

    public class Sound : ControlDO
    {

    }

    public class SourceCode : ControlDO
    {

    }

}