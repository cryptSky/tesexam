using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class ItemDO : Entity
    {
        public QuestionDO Question { get; set; }
        public IEnumerable<VariantDO> Variants { get; set; }
        public AnswerDO CorrectAnswer { get; set; }
    }
}
