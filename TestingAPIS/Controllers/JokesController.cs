using Microsoft.AspNetCore.Mvc;
using TestingAPIS.Services;

namespace TestingAPIS.Controllers
{
    [Route("[controller]")]
    public class JokesController : ControllerBase
    {
        private readonly IJokeService _jokeService;

        public JokesController(IJokeService jokeService) 
        {
            _jokeService = jokeService;
        }
        [HttpGet]
        public IEnumerable<Joke> Index()
        {
            return _jokeService.GetAllJokes();
        }
        [HttpPost]
        public Joke PostJoke(Joke newJoke)
        {
            return _jokeService.AddJoke(newJoke);
        }
        [HttpGet("{id}")]
        public ActionResult<Joke> GetJokeById(int id)
        {
            var result = _jokeService.GetJokeById(id);

            if (result == null)
            {
                return NotFound("id not found");
            }

            return Ok(result);
        }
    }
}
