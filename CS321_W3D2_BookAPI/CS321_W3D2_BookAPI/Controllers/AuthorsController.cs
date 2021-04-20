using CS321_W3D2_BookAPI.Models;
using CS321_W3D2_BookAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace CS321_W3D2_BookAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly AuthorService _authorService;

        // Constructor
        public AuthorsController(AuthorService authorService)
        {
            _authorService = authorService;
        }
        
        // GET api/books
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_authorService.GetAll());
        }

        // get specific book by id
        // GET api/books/:id
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var book = _authorService.Get(id);
            if (book == null) return NotFound();
            return Ok(book);
        }

        // create a new book
        // POST api/books
        [HttpPost]
        public IActionResult Post([FromBody] Author newAuthor)
        {
            try
            {
                // add the new book
                _authorService.Add(newAuthor);
            }
            catch (System.Exception ex)
            {
                ModelState.AddModelError("AddBook", ex.GetBaseException().Message);
                return BadRequest(ModelState);
            }

            // return a 201 Created status. This will also add a "location" header
            // with the URI of the new book. E.g., /api/books/99, if the new is 99
            return CreatedAtAction("Get", new { Id = newAuthor.Id }, newAuthor);
        }
        
        // PUT api/books/:id
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Author updatedAuthor)
        {
            var book = _authorService.Get(id);
            if (book == null) return NotFound();
            _authorService.Update(updatedAuthor);
            return Ok(book);
        }
        
        // DELETE api/books/:id
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var book = _authorService.Get(id);
            if (book == null) return NotFound();
            _authorService.Remove(book);
            return NoContent();
        }
    }
}
