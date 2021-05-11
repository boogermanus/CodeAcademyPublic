using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using QuizApp.ApiModels;
using QuizApp.Core.Services;

namespace QuizApp.Controllers
{
    [Route("api/[controller]")]
    public class QuizzesController : Controller
    {

        private readonly IQuizService _quizService;

        public QuizzesController(IQuizService quizService)
        {
            _quizService = quizService;
        }

        [HttpGet()]
        public IActionResult GetQuizzes()
        {
            //ModelState.AddModelError("GetQuizzes", "Not Implemented!");
            //return BadRequest(ModelState);
            var quizzes = _quizService.GetAll().ToList();
            return Ok(quizzes.ToApiModels());
        }

        [HttpGet("{id}")]
        public IActionResult GetQuiz(int id)
        {
            //ModelState.AddModelError("GetQuiz", "Not Implemented!");
            //return BadRequest(ModelState);
            var quiz = _quizService.Get(id);
            return Ok(quiz.ToApiModel());
        }

        // OPTIONAL - PUSH YOURSELF FURTHER
        // Implement a controller action that will return
        // a quiz containing five randomly selected questions.
        [HttpGet("random")]
        public IActionResult GetRandomQuiz(int id)
        {
            //ModelState.AddModelError("GetRandomQuiz", "Not Implemented!");
            //return BadRequest(ModelState);
            var quiz = _quizService.GetRandomQuiz();
            return Ok(quiz.ToApiModel());
        }
    }
}
