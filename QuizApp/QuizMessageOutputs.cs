using QuizApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuizApp
{
    static class QuizMessageOutputs
    {
        // Display the success message to the user
        public static void SuccessMessage(string answer)
        {
            string message = $"Congrats, you guessed {answer}. That was correct!";
            Console.WriteLine(message);
        }

        // Display the failure message to the user
        public static void FailureMessage(string answer, string correctAnswer)
        {
            string message = $"Sorry, you guessed {answer}. That was incorrect. The correct answer was: {correctAnswer}";
            Console.WriteLine(message);
        }

        // Diplay the question to the user
        public static void DisplayQuestion(Question question)
        {
            StringBuilder message = new StringBuilder($"{question.question}\n");
            foreach (var answer in question.answers)
            {
                message.Append($"{answer.Answer}\n");
            }
            Console.WriteLine(message);
        }

        // Displays reenter message if user enters wrong input
        public static void ReenterMessage(string answer)
        {
            StringBuilder message = new StringBuilder($"The answer you gave: {answer}, was not one of the possible answers." +
                $"\nPlease enter one of the possible answers.");

            Console.WriteLine(message);
        }

        // Display the users score
        public static void DisplayScore(int quizScore)
        {
            StringBuilder message = new StringBuilder($"Congrats, you have finished the quiz. Your total score was: {quizScore}.");
            Console.WriteLine(message);
        }
    }
}
