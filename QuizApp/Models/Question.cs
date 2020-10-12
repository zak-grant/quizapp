using System;
using System.Collections.Generic;
using System.Text;

namespace QuizApp.Models
{
    class Question
    {
        // The question to be asked
        public string question { get; set; }

        // List of possible answers to question
        public List<QuestionAnswer> answers { get; set; }

        // The correct answer
        public int correctAnswer { get; set; }

        // The users guess
        public int UsersGuess { get; set; }

        // Store if the answer was correct or not
        public bool IsCorrect;
    }
}
