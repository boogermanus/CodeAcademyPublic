using System;
using System.Collections.Generic;
using QuizApp.Core.Models;

namespace QuizApp.Core.Services
{
    public interface IQuestionRepository 
    {
        Question Add(Question entity);
        Question Get(int id);
        IEnumerable<Question> GetAll();
        Question Update(Question entity);
        void Remove(Question entity);
    }
}
