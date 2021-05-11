using System;
using System.Collections.Generic;

namespace QuizApp.Core.Models
{

    public class Question : IEntity<int>
    {
        public int Id { get; set; }
        public string QuestionType { get; set; }
        public string Prompt { get; set; }
        public ICollection<Answer> Answers { get; set; }
        //public ICollection<QuestionTopic> QuestionTopics { get; set; }
        public ICollection<QuizQuestion> QuizQuestions { get; set; }
    }
}
    