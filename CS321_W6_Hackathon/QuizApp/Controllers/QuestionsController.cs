using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuizApp.ApiModels;
using QuizApp.Core.Services;

namespace QuizApp.Controllers
{
    [Route("api/[controller]")]
    public class QuestionsController : Controller
    {

        private readonly IQuestionService _questionService;
        
        public QuestionsController(IQuestionService service)
        {
            _questionService = service;
        }
        
        // kinda pointless since we don't have [Authorize]
        [AllowAnonymous]
        [HttpGet()]
        public IActionResult GetAll()
        {
            return Ok(_questionService.GetAll().ToApiModels());
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_questionService.Get(id).ToApiModel());
        }

        [Authorize]
        [HttpPost]
        public IActionResult Add([FromBody]QuestionModel model)
        {

            try
            {
                return Ok(_questionService.Add(model.ToDomainModel()).ToApiModel());
            }
            catch (Exception e)
            {
                ModelState.AddModelError("QuestionAdd", e.Message);
                return BadRequest(ModelState);
            }
        }

        [Authorize]
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] QuestionModel questionModel)
        {
            try
            {
                var found = _questionService.Get(id);

                if (found == null)
                    return NotFound();

                return Ok(_questionService.Update(questionModel.ToDomainModel()).ToApiModel());
            }
            catch (Exception e)
            {
                ModelState.AddModelError("QuestionUpdate", e.Message);
                return BadRequest(ModelState);
            }
        }

        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {
            try
            {
                _questionService.Remove(id);
                return NoContent();
            }
            catch (Exception e)
            {
                ModelState.AddModelError("QuestionRemove", e.Message);
                return BadRequest(ModelState);
            }
        }
    }
}
