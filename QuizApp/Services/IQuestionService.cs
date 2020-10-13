using QuizApp.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace QuizApp.Services
{
    public interface IQuestionService
    {
        List<string> GetQuestionData();

        List<Question> BuildQuestions();

        List<Question> MapQuestionsFromData(List<string> questions);
    }
}
