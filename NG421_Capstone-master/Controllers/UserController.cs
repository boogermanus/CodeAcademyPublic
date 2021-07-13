using System.Collections.Generic;
using System.Linq;
using capstone.Data;
using capstone.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace capstone.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        ApplicationDbContext _context;
        public UserController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IEnumerable<ApplicationUser>> Get()
        {
            return await _context.Users.ToListAsync();
        }
    }
}
