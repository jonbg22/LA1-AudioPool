using AudioPool.Models.InputModels;
using Microsoft.AspNetCore.Mvc;

namespace AudioPool.WebApi.Implimentations
{
    [ApiController]
    [Route("songs")]
    public class SongController : ControllerBase
    {
        [HttpGet("")]
        public IActionResult GetSongById(int id)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteSong(int id)
        {
            throw new NotImplementedException();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateSong(SongInputModel song, int id)
        {
            throw new NotImplementedException();
        }

        [HttpPost("")]
        public IActionResult CreateNewSong(SongInputModel song)
        {
            throw new NotImplementedException();
        }
    }
}