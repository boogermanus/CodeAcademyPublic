using System;
using System.Collections.Generic;

namespace QuizApp.Core.Models
{
    public class Quiz : IEntity<int>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Instructions { get; set; }
        public ICollection<QuizQuestion> QuizQuestions { get; set; }
    }
}
