using NUnit.Framework;
using QuizApp.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuizAppTests
{
    [TestFixture]
    class CheckDataTest
    {

        [Test]
        public void ExistingQuiz()
        {
            QuestionService questionService = new QuestionService();
            var data = questionService.GetData(@"../../../../questions.txt");
            Assert.IsNotNull(data);
        }

        [Test]
        public void NonExistingQuiz()
        {
            QuestionService questionService = new QuestionService();

            Assert.Throws(typeof(System.IO.FileNotFoundException), () => questionService.GetData(@"../../../../nullQuestions.txt"));
        }

        [Test]
        public void CheckNumberOfQuestions()
        {
            QuestionService questionService = new QuestionService();

            var questions = questionService.BuildQuestions();

            Assert.AreEqual(4, questions.Count);
        }
    }
}
