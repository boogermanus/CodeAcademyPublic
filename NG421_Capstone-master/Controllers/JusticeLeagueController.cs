using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using capstone.Data;
using capstone.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace capstone.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class JusticeLeagueController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        
        public JusticeLeagueController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<JusticeLeagueMember>> Get()
        {
            var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            JusticeLeagueMember[] members = null;
                members =  await _context.JusticeLeagueMembers.Where(m => m.UserId == userId).ToArrayAsync();
            return members;
            
        }

        [HttpPost]
        public async Task<JusticeLeagueMember> Post([FromBody]JusticeLeagueMember member)
        {
            member.UserId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            await _context.JusticeLeagueMembers.AddAsync(member);
            await _context.SaveChangesAsync();

            return member;
        }
    }
}
