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
                // TODO: Map domain properties to equivalent ApiModel properties
                // Id
                // Title
                // Instructions               
                Id = quiz.Id,
                Title = quiz.Title,
                Description = quiz.Description,
                Instructions = quiz.Instructions,

                // HINT: Mapping Questions from domain to api model is trickier than what you've
                // seen before due to the intermediate QuizQuestion entity. Use the following
                // for Questions:
                // Questions = quiz.QuizQuestions?
                //    .Select(qq => qq.Question)
                //    .ToApiModels()
                //    .ToList()
                Questions = quiz.QuizQuestions?.Select(qq => qq.Question).ToApiModels().ToList()
            };
		}

		public static Quiz ToDomainModel(this QuizModel quizModel)
		{
			return new Quiz
			{
                // OPTIONAL TODO: Map domain properties to equivalent ApiModel properties
                // THIS IS OPTIONAL. It isn't used in this project since we don't
                // allow creation or updating of quizzes.
                Id = quizModel.Id,
				Title = quizModel.Title,
                Description = quizModel.Description,
                Instructions = quizModel.Instructions,
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
