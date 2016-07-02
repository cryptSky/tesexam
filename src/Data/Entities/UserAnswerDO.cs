using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;


namespace Data.Entities
{
        
    [BsonDiscriminator(RootClass = true)]
    [BsonKnownTypes(typeof(SingleChoiceAnswer), typeof(MultipleChoiceAnswer), typeof(AudioAnswer), typeof(TextAnswer), typeof(LaTexAnswer), typeof(SourceCodeAnswer))]
    public abstract class UserAnswerDO
    {
        public abstract void SetValue(object value);
    }

    public class SingleChoiceAnswer : UserAnswerDO
    {
        public int Value { get; set; }

        public override void SetValue(object value)
        {
            Value = (int)value;
        }
    }

    public class MultipleChoiceAnswer : UserAnswerDO
    {
        public List<int> Values { get; set; }

        public override void SetValue(object value)
        {
            Values.Add((int)value);
        }
    }

    public class AudioAnswer : UserAnswerDO
    {
        public override void SetValue(object value)
        {
            throw new NotImplementedException();
        }
    }

    public class TextAnswer : UserAnswerDO
    {
            public string Value { get; set; }

        public override void SetValue(object value)
        {
            throw new NotImplementedException();
        }
    }

    public class LaTexAnswer : UserAnswerDO
    {
        public string Value { get; set; }

        public override void SetValue(object value)
        {
            throw new NotImplementedException();
        }
    }

    public class SourceCodeAnswer : UserAnswerDO
    {
        public string Value { get; set; }

        public override void SetValue(object value)
        {
            throw new NotImplementedException();
        }
    }

}
