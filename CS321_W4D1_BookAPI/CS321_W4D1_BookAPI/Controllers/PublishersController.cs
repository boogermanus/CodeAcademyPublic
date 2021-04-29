using CS321_W4D1_BookAPI.ApiModels;
using CS321_W4D1_BookAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace CS321_W4D1_BookAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublishersController : ControllerBase
    {
        private readonly IPublisherService _publisherService;

        public PublishersController(IPublisherService publisherService)
        {
            _publisherService = publisherService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var publishers = _publisherService.GetAll();

            return Ok(publishers.ToApiModels());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var publisher = _publisherService.Get(id);

            if (publisher == null)
                return NotFound();

            return Ok(publisher.ToApiModel());
        }
    }
}