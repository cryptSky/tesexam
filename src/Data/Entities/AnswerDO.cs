using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    [BsonDiscriminator(RootClass = true)]
    [BsonKnownTypes(typeof(SingleChoiceAnswer), typeof(MultipleChoiceAnswer), typeof(SoundAnswer), typeof(TextAnswer), typeof(LaTexAnswer))]
    public abstract class AnswerDO : Entity
    {
        
    }
    public class SingleChoiceAnswer : AnswerDO
    {
        public ObjectId VarianId { get; set; }
    }

    public class MultipleChoiceAnswer : AnswerDO
    {
        public IEnumerable<ObjectId> VariantIds { get; set; }
    }

    public class SoundAnswer : AnswerDO
    {

    }

    public class TextAnswer : AnswerDO
    {
        public string Value { get; set; }
    }

    public class LaTexAnswer : AnswerDO
    {
        public string Value { get; set; }
    }
}
