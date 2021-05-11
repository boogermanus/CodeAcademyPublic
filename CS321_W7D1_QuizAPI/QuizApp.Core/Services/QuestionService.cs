using System;
using System.Collections.Generic;
using System.Linq;
using QuizApp.Core.Models;

namespace QuizApp.Core.Services
{
    public class QuestionService : IQuestionService
    {
        private readonly IQuestionRepository _questionRepo;

        public QuestionService(IQuestionRepository questionRepo)
        {
            _questionRepo = questionRepo;
        }

        public Question Add(Question newQuestion)
        {
            if (newQuestion.Answers.Count(a => a.IsCorrect) != 1)
            {
                throw new ApplicationException("A question should have exactly one correct answer.");
            }
            return _questionRepo.Add(newQuestion);
        }

        public Question Get(int id)
        {
            return _questionRepo.Get(id);
        }

        public IEnumerable<Question> GetAll()
        {
            return _questionRepo.GetAll();
        }

        public void Remove(int id)
        {
            var q = _questionRepo.Get(id);
            _questionRepo.Remove(q);
        }

        public Question Update(Question updatedQuestion)
        {
            return _questionRepo.Update(updatedQuestion);
        }
    }
}
