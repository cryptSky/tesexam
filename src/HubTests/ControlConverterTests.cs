
using Data.Entities;
using Data.Infrastructure.JsonNET;
using HubTests.Fixtures;
using Newtonsoft.Json;
using Xunit;

namespace HubTests
{
    public class ControlConverterTests
    {
        [Fact]
        public void Serialization_Success()
        {
            var quiz = QuizFixture.QuizFixture_1();
            string json = JsonConvert.SerializeObject(quiz, Formatting.Indented, new ContentConverter());

            QuizDO newQuiz = JsonConvert.DeserializeObject<QuizDO>(json, new ContentConverter());

            int i = 0;

        }
    }
}
