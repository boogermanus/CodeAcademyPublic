using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace MyFirstAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ValuesController : ControllerBase
    {
        private readonly string[] _values = new[] {"value1", "value2", "value3"};
        
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return _values;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            id--;

            if (id > 2)
                return NotFound();

            return Ok(_values[id]);
        }
    }
}
