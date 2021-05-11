using System;
namespace QuizApp.Core.Models
{
    public interface IEntity<TKey>
    {
        TKey Id { get; set; }
    }
}
