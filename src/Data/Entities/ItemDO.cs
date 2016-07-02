using System.Collections.Generic;
using Data.Infrastructure.JsonNET;
using Newtonsoft.Json;

namespace Data.Entities
{
    public class ItemDO
    {
        public QuestionDO Question { get; set; }
        public List<AnswerDO> PossibleAnswers { get; set; }

        [JsonConverter(typeof(UserAnswerConverter))]
        public UserAnswerDO CorrectAnswer { get; set; }

        public ItemDO()
        {
            PossibleAnswers = new List<AnswerDO>();
        }

        public void SetQuestion(QuestionDO question)
        {
            Question = question;
        }

        public void AddPossibleAnswer(AnswerDO variant)
        {
            PossibleAnswers.Add(variant);            
            
        }

        public void SetCorrectAnswer(UserAnswerDO correctAnswer)
        {
            CorrectAnswer = correctAnswer;
        }
    }
}
