using System;
using CS321_W5D2_BlogAPI.Core.Models;

namespace CS321_W5D2_BlogAPI.Infrastructure.Data
{
    public class CommentRepository : Repository<Comment, int>
    {
        public CommentRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
