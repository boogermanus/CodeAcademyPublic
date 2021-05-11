using System;
using System.Collections.Generic;
using System.Linq;
using QuizApp.ApiModels;
using QuizApp.Core.Models;

namespace QuizApp.ApiModels
{
	public static class QuestionMappingExtensions
	{

		public static QuestionModel ToApiModel(this Question item)
		{
			return new QuestionModel
            {
	            Id = item.Id,
	            QuestionType = item.QuestionType,
	            Prompt = item.Prompt,
	            Answers = item.Answers.ToApiModels().ToList()
            };
        }

		public static Question ToDomainModel(this QuestionModel item)
		{
			return new Question
			{
				Id = item.Id,
				QuestionType = item.QuestionType,
				Prompt = item.Prompt,
				Answers = item.Answers.ToDomainModels().ToList()
			};
		}

		public static IEnumerable<QuestionModel> ToApiModels(this IEnumerable<Question> items)
		{
			return items.Select(a => a.ToApiModel());
		}

		public static IEnumerable<Question> ToDomainModels(this IEnumerable<QuestionModel> items)
		{
			return items.Select(a => a.ToDomainModel());
		}
	}
}
