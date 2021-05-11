using System;
using System.Collections.Generic;
using QuizApp.Core.Models;

namespace QuizApp.ApiModels
{
    public class QuestionModel
    {
        public int Id { get; set; }
        public string QuestionType { get; set; }
        public string Prompt { get; set; }
        public IEnumerable<AnswerModel> Answers { get; set; }
    }
}
