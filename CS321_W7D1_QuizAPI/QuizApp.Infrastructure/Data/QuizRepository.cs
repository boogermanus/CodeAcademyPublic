using System;
using System.Collections.Generic;
using QuizApp.Core.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using QuizApp.Core.Services;

namespace QuizApp.Infrastructure.Data
{
    public class QuizRepository : Repository<Quiz, int>, IQuizRepository
    {
        public QuizRepository(AppDbContext dbContext) : base(dbContext)
        {
        }

        public override IEnumerable<Quiz> GetAll()
        {
            return Entities
                .Include(q => q.QuizQuestions)
                    .ThenInclude(qq => qq.Question)
                    .ThenInclude(q => q.Answers)
                .ToList();
        }

        public override Quiz Get(int id)
        {
            return Entities
                .Include(q => q.QuizQuestions)
                    .ThenInclude(qq => qq.Question)
                    .ThenInclude(q => q.Answers)
                .SingleOrDefault(q => q.Id == id);
        }
    }
}
