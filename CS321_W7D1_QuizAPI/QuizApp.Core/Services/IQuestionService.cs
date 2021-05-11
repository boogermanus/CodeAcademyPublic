using System;
using System.Collections.Generic;
using QuizApp.Core.Models;

namespace QuizApp.Core.Services
{
    public interface IQuestionService
    {
        Question Get(int id);
        IEnumerable<Question> GetAll();
        Question Add(Question newQuestion);
        Question Update(Question updatedQuestion);
        void Remove(int id);
    }
}
