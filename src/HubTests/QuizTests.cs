using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HubTests.Fixtures;

using Xunit;
using Hub.Interfaces;
using Hub.Services;

namespace HubTests
{
    public class QuizTests
    {
        private QuizService _quizCreator;

        public QuizTests(IQuizService quizCreator)
        {
           
        }

        [Fact]
        public void AddQuizIntoDB_Success()
        {
            var quiz = QuizFixture.QuizFixture_1();
            
            
        }
    }
}
