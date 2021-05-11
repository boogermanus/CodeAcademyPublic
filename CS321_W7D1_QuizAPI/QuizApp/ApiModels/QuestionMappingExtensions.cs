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
            // TODO: map domain properties to equivalent apiModel properties
            // Id
            // QuestionType
            // Prompt
            // Answers
            return new QuestionModel
            {
                Id = item.Id,
                QuestionType = item.QuestionType,
                Prompt = item.Prompt,
                Answers = item.Answers?.ToApiModels().ToList()
                // HINT: Answers = item.Answers?.ToApiModels().ToList()
            };
        }

		public static Question ToDomainModel(this QuestionModel item)
		{
            // TODO: map api model props to equivalent domain props
            // Id
            // QuestionType
            // Prompt
            // Answers
			return new Question
			{
				Id = item.Id,
                QuestionType = item.QuestionType,
                Prompt = item.Prompt,
                Answers = item.Answers?.ToDomainModels().ToList(),
                // HINT: Answers is similar to above, but uses Domain Models
                // HINT: you can ignore QuizQuestions
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
