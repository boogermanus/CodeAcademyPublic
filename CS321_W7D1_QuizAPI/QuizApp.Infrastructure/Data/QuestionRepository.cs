using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using QuizApp.Core.Models;
using QuizApp.Core.Services;

namespace QuizApp.Infrastructure.Data
{
    public class QuestionRepository : Repository<Question, int>, IQuestionRepository
    {
        public QuestionRepository(AppDbContext dbContext) : base(dbContext)
        {
        }

        public override Question Get(int id)
        {
            return Entities
                .Include(q => q.Answers)
                .SingleOrDefault(q => q.Id == id);
        }

        public override IEnumerable<Question> GetAll()
        {
            return Entities
                .Include(q => q.Answers)
                .ToList();
        }

        public override Question Update(Question updatedItem)
        {
            // retrieve the existing question
            var existingItem = this.Get(updatedItem.Id);
            if (existingItem == null) return null;

            // copy updated property values into the existing question
            _dbContext.Entry(existingItem)
               .CurrentValues
               .SetValues(updatedItem);

            // loop thru all of the answers in the updated question
            foreach(var updatedAnswer in updatedItem.Answers)
            {
                // find the existing answer that corresponds to the updated answer
                var existingAnswer = existingItem.Answers
                .Where(a => a.Id == updatedAnswer.Id)
                .SingleOrDefault();
                // update existing answer from updated answer
                _dbContext.Entry(existingAnswer)
                    .CurrentValues
                    .SetValues(updatedAnswer);
            }

            // save all the changes
            _dbSet.Update(existingItem);
            _dbContext.SaveChanges();
            return existingItem;
        }
    }
}
