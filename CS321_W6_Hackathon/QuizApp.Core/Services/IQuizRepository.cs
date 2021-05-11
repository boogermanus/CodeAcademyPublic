using System;
using System.Collections.Generic;
using QuizApp.Core.Models;

namespace QuizApp.Core.Services
{
    public interface IQuizRepository 
    {
        Quiz Add(Quiz entity);
        Quiz Get(int id);
        IEnumerable<Quiz> GetAll();
        Quiz Update(Quiz entity);
        void Remove(Quiz entity);
    }
}
