using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.Extensions.Logging;
using QuizApp.Models;

namespace QuizApp.Services
{
    public class QuestionService : IQuestionService
    {
        /// <summary>
        /// Get list of questions back from text file
        /// </summary>
        /// <returns>List<Question></returns>
        public List<Question> BuildQuestions()
        {
            // Get back data first
            var data = GetQuestionData();

            // Map data to questions
            var questions = MapQuestionsFromData(data);

            // Return questions
            return questions;
        }

        /// <summary>
        /// Method to attempt to get list of questions
        /// </summary>
        /// <returns> List<string></returns>
        public List<string> GetQuestionData()
        {
            // Create a new list of strings to store data
            List<string> data = new List<string>();

            // Try to get list of string data from text file
            try
            {
                // Need the file name where the questions are stored
                string fileName = @"../../../../questions.txt";

                // Get data from file
                data = GetData(fileName);
            }
            // If not able to get data back
            catch (Exception e)
            {
                // Record stack trace for future debugging
                Console.WriteLine("Unable to retireve data. Please restart applciation.");
            }

            return data;
        }

        /// <summary>
        /// Method to grab data(list of questions) from text file
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns>List<strings></returns>
        public List<string> GetData(string fileName)
        {
            // Read all lines from the text document
            return File.ReadLines(fileName).ToList();
        }

        /// <summary>
        /// Method to map list of strings to a list of questions
        /// </summary>
        /// <param name="questionData"></param>
        /// <returns>List<Quesitons></returns>
        public List<Question> MapQuestionsFromData(List<string> questionData)
        {
            // Create question model for storing data in
            Question tempQuestion = new Question();

            List<Question> questions = new List<Question>();

            for (int i = 0; i < questionData.Count; i++)
            {
                // Check if is first line of question
                if (questionData[i].StartsWith('('))
                {
                    // Create new question to store question data in
                    tempQuestion = new Question();

                    // Fill in question field
                    tempQuestion.question = questionData[i];

                    int questionNumber;

                    // Parse answer number from question and store in answer
                    bool isNumber = Int32.TryParse(tempQuestion.question[1].ToString(), out questionNumber);

                    // Get question number
                    tempQuestion.QuestionNumber = questionNumber;
                }
                else if ((i == questionData.Count - 1) || questionData[i + 1].StartsWith('('))
                { 
                    int answer;

                    // Parse answer number from question and store in answer
                    bool isNumber = Int32.TryParse(questionData[i], out answer);

                    if (isNumber)
                    {
                        // Assign correct answer to correctAnswer property in tempQuestion
                        tempQuestion.correctAnswer = answer;

                        // This would mean that the question has been filled in, and can be added to list of questions to be returned
                        questions.Add(tempQuestion);
                    }
                }
                else
                {
                    if (tempQuestion.answers == null)
                    {
                        // If null, create a new list of strings
                        tempQuestion.answers = new List<QuestionAnswer>();
                    }

                    // Create a new QuestionAnswer to hold the answer data
                    QuestionAnswer questionAnswer = new QuestionAnswer
                    {
                        // Id will help us to match up the correct answer
                        Id = tempQuestion.answers.Count + 1,

                        // Holds the actual sting answer
                        Answer = questionData[i]
                    };

                    // Add answer to possible list of answers for question
                    tempQuestion.answers.Add(questionAnswer);
                }
            }

            // Return questions
            return questions;
        }
    }
}
