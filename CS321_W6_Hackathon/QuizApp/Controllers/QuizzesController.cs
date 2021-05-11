using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using QuizApp.ApiModels;
using QuizApp.Core.Services;

namespace QuizApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuizzesController : Controller
    {

        private readonly IQuizService _quizService;

        public QuizzesController(IQuizService quizService)
        {
            _quizService = quizService;
        }
        
        [HttpGet]
        public IActionResult GetQuizzes()
        {
            return Ok(_quizService.GetAll().ToApiModels());
        }

        [HttpGet("{id}")]
        public IActionResult GetQuiz(int id)
        {
            var quiz = _quizService.Get(id);

            if (quiz == null)
                return NotFound();

            return Ok(quiz.ToApiModel());
        }

        // OPTIONAL - PUSH YOURSELF FURTHER
        // Implement a controller action that will return
        // a quiz containing five randomly selected questions.
    }
}
