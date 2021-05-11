using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using QuizApp.Core.Models;
using QuizApp.Core.Services;

namespace QuizApp.Infrastructure.Data
{
    public class QuestionRepository : IQuestionRepository
    {
        // TODO: inherit and implement the IQuestionRepository interface

        private AppDbContext _dbContext;
        public QuestionRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public Question Add(Question entity)
        {
            _dbContext.Questions.Add(entity);
            _dbContext.SaveChanges();
            return entity;
        }

        public Question Get(int id)
        {
            return _dbContext.Questions
                .Include(q => q.Answers)
                .FirstOrDefault(q => q.Id == id);
        }

        public IEnumerable<Question> GetAll()
        {
            return _dbContext.Questions
                .Include(q => q.Answers)
                .ToList();
        }
        
        public Question Update(Question updatedItem)
        {
            // retrieve the existing question
            var existingItem = this.Get(updatedItem.Id);
            if (existingItem == null) return null;

            // copy updated property values into the existing question
            _dbContext.Entry(existingItem)
               .CurrentValues
               .SetValues(updatedItem);

            // loop thru all of the answers in the updated question
            foreach (var updatedAnswer in updatedItem.Answers)
            {
                // find the existing answer that corresponds to the updated answer
                var existingAnswer = existingItem.Answers
                    .SingleOrDefault(a => a.Id == updatedAnswer.Id);
                // update existing answer from updated answer
                
                //don't update a null answer!
                if(existingAnswer == null)
                    continue;
                
                _dbContext.Entry(existingAnswer)
                    .CurrentValues
                    .SetValues(updatedAnswer);
            }

            // save all the changes
            _dbContext.Questions.Update(existingItem);
            _dbContext.SaveChanges();
            return existingItem;
        }
        public void Remove(Question entity)
        {
            // this needs some research and might not even be needed.
            // throw new NotImplementedException();
            
            // we'll try this for now...
            _dbContext.Remove(entity);
            _dbContext.SaveChanges();
        }
    }
}
