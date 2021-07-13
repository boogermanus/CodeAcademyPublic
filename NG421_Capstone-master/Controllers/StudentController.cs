using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using capstone.Data;
using capstone.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace capstone.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class StudentController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Student> Get()
        {
            Student[] students = null;
            using (var context = new ApplicationDbContext())
            {
                students =  context.Students.ToArray();
            }
            return students;
            
        }
    }
}
