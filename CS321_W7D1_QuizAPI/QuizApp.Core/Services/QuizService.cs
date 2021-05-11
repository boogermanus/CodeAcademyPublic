using System;
using System.Collections.Generic;
using System.Linq;
using QuizApp.Core.Models;

namespace QuizApp.Core.Services
{
    public class QuizService : IQuizService
    {
        private readonly IQuizRepository _quizRepo;
        private readonly IQuestionRepository _questionRepo;

        public QuizService(IQuizRepository quizRepo, IQuestionRepository questionRepo)
        {
            _quizRepo = quizRepo;
            _questionRepo = questionRepo;
        }

        public Quiz Get(int id)
        {
            var quiz = _quizRepo.Get(id);
            return quiz;
        }

        public IEnumerable<Quiz> GetAll()
        {
            var quizzes = _quizRepo.GetAll();
            return quizzes;
        }


        // PUSH YOURSELF FURTHER
        // TIPS:
        //    * You'll need the QuestionRepository in order to get the list of questions to randomly choose from. How do you inject it?
        //    * You don't need to save the new quiz to the database. Just create
        //      a new Quiz object in memory and return it.
        //    * Remember that a domain Quiz has an extra layer (QuizQuestions) between Quiz and Question.
        public Quiz GetRandomQuiz()
        {
            var questions = _questionRepo.GetAll().ToList();
            var random = new Random();

            var newQuiz = new Quiz
            {
                Id = 0,
                Title = "A Random Quiz",
                Description = "The questions have been randomly selected.",
                QuizQuestions = new List<QuizQuestion>()
            };

            for (int i = 0; i < 5; i++)
            {
                var randomIndex = random.Next(0, questions.Count - 1);
                var randomQuestion = questions[randomIndex];
                newQuiz.QuizQuestions.Add(
                    new QuizQuestion
                    {
                        QuizId = 0,
                        Quiz = newQuiz,
                        QuestionId = randomQuestion.Id,
                        Question = randomQuestion
                    });
            }
            return newQuiz;
        }
    }
}
