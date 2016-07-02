
using Data.Entities;
using System.Collections.Generic;

namespace HubTests.Fixtures
{
    public class QuizFixture
    {
        public static QuizDO QuizFixture_1()
        {
            var quiz = new QuizDO();
            quiz.AnswerTime = 3000;

            var questionLabel = new Label { Text = "What is the highest mountain of the world?" };
            var questionImage = new Image { ImagePath = "cdn://dksjdksjkd.com/image.png" };
            var questionContent = new ContentDO();
            questionContent.AddControl(questionLabel);
            questionContent.AddControl(questionImage);

            var question = new QuestionDO();
            question.Content = questionContent;

            var quizItem = new ItemDO();
            quizItem.SetQuestion(question);

            for (int i = 0; i < 4; ++i)
            {
                var answerLabel = new Label { Text = "Everest" };
                var answerImage = new Image { ImagePath = "cdn://dkhfjdkl.io/everest.png" };
                var answerContent = new ContentDO();
                answerContent.AddControl(answerLabel);
                answerContent.AddControl(answerImage);

                var answer = new AnswerDO();
                answer.Content = answerContent;

                quizItem.AddPossibleAnswer(answer);
            }

            quizItem.SetCorrectAnswer(new SingleChoiceAnswer { Value = 1 });

            quiz.AddQuizItem(quizItem);

            return quiz;

        }
    }
}
