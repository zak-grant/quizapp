using NUnit.Framework;
using QuizApp;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuizAppTests
{
    [TestFixture]
    class QuizTests
    {
        [Test]
        public void BuildQuestionsTest()
        {
            QuizOperation quiz = new QuizOperation();
            var quizQuestions = quiz.BuildQuizQuestions();
            Assert.AreEqual(4,quizQuestions.Count);
        }

        [Test]
        public void CheckForCorrectScore()
        {
            QuizOperation quiz = new QuizOperation();
            var quizQuestions = quiz.BuildQuizQuestions();
            quiz.CheckIfAnswerCorrect(1, quizQuestions[1]);
            Assert.AreEqual(4, quizQuestions.Count);
        }
    }
}
