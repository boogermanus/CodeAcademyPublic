using System;
using System.Collections.Generic;
using QuizApp.Core.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using QuizApp.Core.Services;

namespace QuizApp.Infrastructure.Data
{
    public class QuizRepository : IQuizRepository
    {
        private readonly AppDbContext _dbContext;
        public QuizRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Quiz Add(Quiz entity)
        {
            _dbContext.Add(entity);
            _dbContext.SaveChanges();
            return entity;
        }

        public Quiz Get(int id)
        {
            return _dbContext.Quizzes
                .Include(q => q.QuizQuestions)
                .ThenInclude(qq => qq.Question)
                .ThenInclude(q => q.Answers)
                .SingleOrDefault(q => q.Id == id);
        }

        public IEnumerable<Quiz> GetAll()
        {
            return _dbContext.Quizzes
                .Include(q => q.QuizQuestions)
                .ThenInclude(qq => qq.Question)
                .ThenInclude(q => q.Answers)
                .ToList();
        }

        public Quiz Update(Quiz entity)
        {
            var current = Get(entity.Id);

            if (current == null)
                return null;

            _dbContext.Entry(current)
                .CurrentValues
                .SetValues(entity);

            _dbContext.Update(current);
            _dbContext.SaveChanges();

            return entity;
        }

        public void Remove(Quiz entity)
        {
            var current = Get(entity.Id);

            if (current == null) 
                return;
            
            _dbContext.Remove(entity);
            _dbContext.SaveChanges();
        }
    }
}
