using System;
using System.Collections.Generic;
using QuizApp.Core.Models;

namespace QuizApp.Core.Services
{
    public interface IQuizService
    {
        Quiz Get(int id);
        IEnumerable<Quiz> GetAll();
        // PUSH YOURSELF FURTHER - TODO: GetRandomQuiz(). Add this later if you decide to try to implement it.
        Quiz GetRandomQuiz();
    }
}
