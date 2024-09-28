using Microsoft.AspNetCore.Mvc;

namespace AudioPool.WebApi.Implimentations
{
    [ApiController]
    [Route("genres")]
    public class GenreController : ControllerBase
    {
        [HttpGet("")]
        public IActionResult GetAllGenres()
        {
            throw new NotImplementedException();
        }

        [HttpGet("{id}")]
        public IActionResult GetGenreById(int id)
        {
            throw new NotImplementedException();
        }

        [HttpPost("{id}")]
        public IActionResult CreateNewGenre(int id)
        {
            throw new NotImplementedException();
        }
    }
}