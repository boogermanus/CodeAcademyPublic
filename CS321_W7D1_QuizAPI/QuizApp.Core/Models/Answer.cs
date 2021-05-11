using System;
namespace QuizApp.Core.Models
{
    public class Answer : IEntity<int>
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public bool IsCorrect { get; set; }
        public int QuestionId { get; set; }
        public Question Question { get; set; }
    }
}
