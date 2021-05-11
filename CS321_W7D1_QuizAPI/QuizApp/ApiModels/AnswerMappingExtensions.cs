using System;
using System.Collections.Generic;
using System.Linq;
using QuizApp.ApiModels;
using QuizApp.Core.Models;

namespace QuizApp.ApiModels
{
	public static class AnswerMappingExtensions
	{

		public static AnswerModel ToApiModel(this Answer item)
		{
			return new AnswerModel
			{
                // TODO: map domain properties to equivalent ApiModel properties
				Id = item.Id,
                QuestionId = item.QuestionId,
                Content = item.Content,
                IsCorrect = item.IsCorrect,                
			};
		}

		public static Answer ToDomainModel(this AnswerModel item)
		{
            // TODO: map ApiModel properties to equivalen domain properties
			return new Answer
			{
				Id = item.Id,
                Content = item.Content,
                QuestionId = item.QuestionId,
                IsCorrect = item.IsCorrect
			};
		}

		public static IEnumerable<AnswerModel> ToApiModels(this IEnumerable<Answer> items)
		{
			return items.Select(a => a.ToApiModel());
		}

		public static IEnumerable<Answer> ToDomainModels(this IEnumerable<AnswerModel> items)
		{
			return items.Select(a => a.ToDomainModel());
		}
	}
}
