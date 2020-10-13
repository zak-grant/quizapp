using Microsoft.Extensions.Logging;
using QuizApp.Models;
using QuizApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp
{
    public class QuizOperation
    {
        private readonly IQuestionService _questionService;

        int quizScore;

        public QuizOperation()
        {
        }

        public QuizOperation(IQuestionService questionService)
        {
            _questionService = questionService;
        }

        public List<Question> BuildQuizQuestions()
        {
            IQuestionService questionService = new QuestionService();
            return questionService.BuildQuestions().OrderBy(x => x.QuestionNumber).ToList();
        }

        public void RunQuiz(List<Question> questions)
        {
            if (questions == null)
            {
                Console.WriteLine("There was a problem with the quiz questions.");
            }

            foreach (var question in questions)                                                                                                                                                            
            {
                // Display the question
                QuizMessageOutputs.DisplayQuestion(question);

                // Get the users answer
                int answer = CheckUserInput(question);

                // Check if answer is correct
                CheckIfAnswerCorrect(answer, question);

                // Add to users score if need be
                AdjustScore(question);
            }

            QuizMessageOutputs.DisplayScore(quizScore);
        }

        /// <summary>
        /// Incriment quiz score if user got question correct
        /// </summary>
        /// <param name="question"></param>
        public void AdjustScore(Question question)
        {
            // Check if question is null
            if (question == null)
            {
                Console.WriteLine("There was an issue with the question");
            }

            // If user got question correct, incriment quiz score
            if (question.IsCorrect == true)
            {
                quizScore++;
            }
        }

        /// <summary>
        /// Check if the users answer is correct
        /// </summary>
        /// <param name="answer"></param>
        public void CheckIfAnswerCorrect(int answer, Question question)
        {
            // Get the correct answer from the list of answers
            var correctAnswer = question.answers.First(x => x.Id == question.correctAnswer);

            if (answer != question.correctAnswer)
            {
                // Set the users answer to false / wrong
                question.IsCorrect = false;

                // Get the matching answer to teh users answer from the lsit of answers
                var inCorrectUsersAnswer = question.answers.First(x => x.Id == question.UsersGuess);

                // Display the failure message using the users incorrect answer, and the correct answer
                QuizMessageOutputs.FailureMessage(inCorrectUsersAnswer.Answer, correctAnswer.Answer);
            }
            else
            {
                // Set the users answer to true / correct
                question.IsCorrect = true;

                // Display the success message using the correct answer
                QuizMessageOutputs.SuccessMessage(correctAnswer.Answer);
            }
        }

        /// <summary>
        /// Check the users answer to ensure write type of data input, and input is possible answer
        /// </summary>
        /// <param name="answers"></param>
        /// <returns></returns>
        private int CheckUserInput(Question question)
        {
            // Get the users answer
            var usersAnswer = Console.ReadLine();

            // Get a list of all possible answers in the question
            List<int> allPossibleAnswers = GetAllPossibleAnswers(question.answers);

            // Create a variable to hold the int value of the answer
            int answer;

            // Run so long as the user does not guess an answer that is a possible answer
            while (usersAnswer == null || !Int32.TryParse(usersAnswer, out answer) || !allPossibleAnswers.Contains(answer))
            {
                // Make sure that the users answer is not some random high number
                usersAnswer = usersAnswer.ToString();

                // Prompt the user to reenter thier answer
                QuizMessageOutputs.ReenterMessage(usersAnswer);

                // Get the users answer again
                usersAnswer = Console.ReadLine();
            }

            // Record the users guess
            question.UsersGuess = answer;

            // Return the answer
            return answer;
        }

        private List<int> GetAllPossibleAnswers(List<QuestionAnswer> answers)
        {
            List<int> ids = new List<int>();
            foreach (var answer in answers)
            {
                ids.Add(answer.Id);
            }

            return ids;
        }
    }
}
