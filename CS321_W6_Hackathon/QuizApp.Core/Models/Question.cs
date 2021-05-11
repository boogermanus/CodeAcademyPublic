using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace QuizApp.Core.Models
{

    public class Question 
    {
        public int Id { get; set; }
        public string QuestionType { get; set; }
        public string Prompt { get; set; } 
        public ICollection<Answer> Answers { get; set; }
        public ICollection<QuizQuestion> QuizQuestions { get; set; }
        
    }
}
    