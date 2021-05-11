using System;
using System.Collections.Generic;
using System.Linq;
using QuizApp.Core.Models;

namespace QuizApp.ApiModels
{
	public static class QuizMappingExtensions
	{

		public static QuizModel ToApiModel(this Quiz quiz)
		{
            return new QuizModel
            {
	            Id = quiz.Id,
                Title = quiz.Title,
                Instructions = quiz.Instructions,
                Description = quiz.Description,
                Questions = quiz.QuizQuestions?
	                .Select(qq => qq.Question)
	                .ToApiModels()
	                .ToList()
            };
		}

		public static Quiz ToDomainModel(this QuizModel quizModel)
		{
			//woh! this seems kinda hard
			return new Quiz
			{
                // OPTIONAL TODO: Map domain properties to equivalent ApiModel properties
                // THIS IS OPTIONAL. It isn't used in this project since we don't
                // allow creation or updating of quizzes.
			};
		}

		public static IEnumerable<QuizModel> ToApiModels(this IEnumerable<Quiz> quizzes)
		{
			return quizzes.Select(a => a.ToApiModel());
		}

		public static IEnumerable<Quiz> ToDomainModels(this IEnumerable<QuizModel> quizModels)
		{
			return quizModels.Select(a => a.ToDomainModel());
		}
	}
}
