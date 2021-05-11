using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using QuizApp.Core.Models;

namespace QuizApp.Core.Services
{
    public class QuestionService : IQuestionService
    {
        private readonly IQuestionRepository _questionRepository;

        public QuestionService(IQuestionRepository questionRepository)
        {
            _questionRepository = questionRepository;
        }
        
        public Question Get(int id)
        {
            return _questionRepository.Get(id);
        }

        public IEnumerable<Question> GetAll()
        {
            return _questionRepository.GetAll();
        }

        public Question Add(Question newQuestion)
        {

            CheckAnswers(newQuestion.Answers);

            newQuestion = _questionRepository.Add(newQuestion);

            return newQuestion;
        }

        private void CheckAnswers(IEnumerable<Answer> answers)
        {
            if (answers == null)
                throw new ValidationException("answers cannot be null");
            
            var list = answers.ToList();

            if (list.Count == 0)
                throw new ValidationException("must have at least one answer");

            if (!list.Any(a => a.IsCorrect))
                throw new ValidationException("must have at least one correct answer");
        }

        public Question Update(Question updatedQuestion)
        {
            CheckAnswers(updatedQuestion.Answers);

            updatedQuestion = _questionRepository.Update(updatedQuestion);

            return updatedQuestion;
        }

        public void Remove(int id)
        {
            var question = Get(id);

            if (question == null)
                throw new ArgumentException($"{id} not found", nameof(id));

            _questionRepository.Remove(question);
        }
    }
}
