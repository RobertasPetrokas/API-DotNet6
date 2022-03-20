using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace TestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private readonly DataContext _dataContext;
        public QuestionController(DataContext context)
        {
            _dataContext = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Question>>> Get()
        {
            return Ok(await _dataContext.Questions.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Question>> Get(int id)
        {
            var question = await _dataContext.Questions.FindAsync(id);
            if (question == null)
                return BadRequest("Question not found");

            return Ok(question);
        }

        [HttpPost]
        public async Task<ActionResult<List<Question>>> AddQuestion(Question question)
        {
            _dataContext.Questions.Add(question);
            await _dataContext.SaveChangesAsync();
            return Ok(await _dataContext.Questions.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Question>>> UpdateQuestion(Question request)
        {
            var question = await _dataContext.Questions.FindAsync(request.Id);
            if (question == null)
                return BadRequest("Question not found");

            question.Title = request.Title;
            question.Options = request.Options;
            question.CorrectAnswer = request.CorrectAnswer;

            await _dataContext.SaveChangesAsync();
            return Ok(await _dataContext.Questions.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Question>>> Delete(int id)
        {
            var question = await _dataContext.Questions.FindAsync(id);
            if (question == null)
                return BadRequest("Question not found");

            _dataContext.Questions.Remove(question);
            await _dataContext.SaveChangesAsync();
            return Ok(await _dataContext.Questions.ToListAsync());
        }
    }
}
