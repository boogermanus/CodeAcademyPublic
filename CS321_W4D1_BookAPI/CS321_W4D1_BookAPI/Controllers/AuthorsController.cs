using CS321_W4D1_BookAPI.ApiModels;
using CS321_W4D1_BookAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace CS321_W4D1_BookAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorService _authorService;

        // Constructor
        public AuthorsController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        // TODO: get all authors
        // GET api/authors
        [HttpGet]
        public IActionResult Get()
        {
            var authorModels = _authorService
                .GetAll()
                .ToApiModels();
            return Ok(authorModels);
        }

        // get specific author by id
        // GET api/authors/:id
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var author = _authorService
                .Get(id)
                .ToApiModel();
            if (author == null) return NotFound();
            return Ok(author);
        }

        // create a new author
        // POST api/authors
        [HttpPost]
        public IActionResult Post([FromBody] AuthorModel newAuthor)
        {
            try
            {
                // add the new author
                _authorService.Add(newAuthor.ToDomainModel());
            }
            catch (System.Exception ex)
            {
                ModelState.AddModelError("AddAuthor", ex.GetBaseException().Message);
                return BadRequest(ModelState);
            }

            // return a 201 Created status. This will also add a "location" header
            // with the URI of the new author. E.g., /api/authors/99, if the new is 99
            return CreatedAtAction("Get", new { Id = newAuthor.Id }, newAuthor);
        }
        
        // PUT api/authors/:id
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] AuthorModel updatedAuthor)
        {
            var author = _authorService.Update(updatedAuthor.ToDomainModel());
            if (author == null) return NotFound();
            return Ok(author);
        }
        
        // DELETE api/authors/:id
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var author = _authorService.Get(id);
            if (author == null) return NotFound();
            _authorService.Remove(author);
            return NoContent();
        }
    }
}
