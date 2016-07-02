using Data.Entities.Enums;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class QuizDO : Entity
    {
        public List<ItemDO> QuizItems { get; set; }

        public int AnswerTime { get; set; }

        public QuizDO()
        {
            QuizItems = new List<ItemDO>();
        }

        public void AddQuizItem(ItemDO item)
        {
            QuizItems.Add(item);
        }
    }
}
