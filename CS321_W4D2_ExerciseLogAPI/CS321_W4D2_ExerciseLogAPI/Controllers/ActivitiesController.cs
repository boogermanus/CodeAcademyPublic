using System;
using CS321_W4D2_ExerciseLogAPI.ApiModels;
using CS321_W4D2_ExerciseLogAPI.Core.Models;
using CS321_W4D2_ExerciseLogAPI.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace CS321_W4D2_ExerciseLogAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ActivitiesController : ControllerBase
    {
        private readonly IActivityService _activityService;

        public ActivitiesController(IActivityService activityService)
        {
            _activityService = activityService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_activityService.GetAll().ToApiModels());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_activityService.Get(id).ToApiModel());
        }

        [HttpPost]
        public IActionResult Post([FromBody]ActivityModel activity)
        {
            try
            {
                return Ok(_activityService.Add(activity.ToDomainModel()));
            }
            catch (Exception e)
            {
                ModelState.AddModelError("Post", e.Message);
                return BadRequest(ModelState);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ActivityModel activity)
        {
            var current = _activityService.Get(id);

            if (current == null)
                return NotFound();

            current = _activityService.Update(activity.ToDomainModel());

            return Ok(current.ToApiModel());
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var current = _activityService.Get(id);

            if (current == null)
                return NotFound();

            _activityService.Remove(current);

            return NoContent();
        }
    }
}