using System;
using CS321_W2D2_StudentAPI.Models;
using CS321_W2D2_StudentAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace CS321_W2D2_StudentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentsService _studentsService;

        // Constructor
        public StudentsController(StudentsService studentsService)
        {
            // HINT: keep a reference to the incoming service
            _studentsService = studentsService;
        }

        // get all students
        // GET api/students
        [HttpGet]
        public IActionResult Get()
        {
            // return OK 200 status and list of students
            return Ok(_studentsService.GetAll());
        }

        // get specific student by id
        // GET api/students/:id
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            // look up student by id
            var student = _studentsService.Get(id);
            // if not found, return 404 NotFound 
            if (student == null) return NotFound();
            // otherwise return 200 OK and the Student
            return Ok(student);
        }

        // create a new student
        // POST api/students
        [HttpPost]
        public IActionResult Post([FromBody] Student newStudent)
        {
            // add the new student
            try
            {
                _studentsService.Add(newStudent);
            }
            catch (Exception e)
            {
                ModelState.AddModelError("Post", e.Message);
                return BadRequest(ModelState);
            }
            
            // return a 201 Created status. This will also add a "location" header
            // with the URI of the new student. E.g., /api/students/99, if the new is 99
            return CreatedAtAction("Get", new { Id = newStudent.Id }, newStudent);
        }

        // update an existing student
        // PUT api/students/:id
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Student updatedStudent)
        {
            var student = _studentsService.Update(updatedStudent);
            if (student == null) return NotFound();
            return Ok(student);
        }

        // delete an existing student
        // DELETE api/students/:id
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var student = _studentsService.Get(id);
            if (student == null) return NotFound();
            _studentsService.Remove(student);
            return NoContent();
        }
    }
}
