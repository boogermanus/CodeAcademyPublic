using System;
using System.Collections.Generic;
using System.Linq;
using QuizApp.Core.Models;

namespace QuizApp.Core.Services
{
    public class QuizService : IQuizService
    {
        private readonly IQuizRepository _quizRepository;

        public QuizService(IQuizRepository quizRepository)
        {
            _quizRepository = quizRepository;
        }
        public Quiz Get(int id)
        {
            return _quizRepository.Get(id);
        }

        public IEnumerable<Quiz> GetAll()
        {
            return _quizRepository.GetAll();
        }
        
        // TODO: inherit and implement the IQuizService interface

        // PUSH YOURSELF FURTHER
        // TIPS:
        //    * You'll need the QuestionRepository in order to get the list of questions to randomly choose from. How do you inject it?
        //    * You don't need to save the new quiz to the database. Just create
        //      a new Quiz object in memory and return it.
        //    * Remember that a domain Quiz has an extra layer (QuizQuestions) between Quiz and Question.
        // public Quiz GetRandomQuiz() { }
    }
}
