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
            // Initial project setup
            ProjectSetup setup = new ProjectSetup();
            setup.InitialProjectSetup();

            // Create new quiz object
            QuizOperation quiz = new QuizOperation();

            // Build quiz questions
            var quizQuestions = quiz.BuildQuizQuestions();

            // Run quiz
            quiz.RunQuiz(quizQuestions);
        }
    }
}
