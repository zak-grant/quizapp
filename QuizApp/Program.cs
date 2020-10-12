using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using QuizApp.Models;
using QuizApp.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace QuizApp
{
    class Program
    {

        static void Main(string[] args)
        {
            ProjectSetup setup = new ProjectSetup();
            setup.InitialProjectSetup();

            QuizOperation quiz = new QuizOperation();

            QuestionService questionService = new QuestionService();

            var quizQuestions = quiz.BuildQuizQuestions();
            quiz.RunQuiz(quizQuestions);
        }
    }
}
