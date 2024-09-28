using AudioPool.Models.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace AudioPool.WebApi.Implimentations
{
    [ApiController]
    [Route("albums")]
    public class AlbumController : ControllerBase
    {
        [HttpGet("")]
        public IActionResult GetAllAlbums()
        {
            throw new NotImplementedException();
        }

        [HttpGet("{id}")]
        public IActionResult GetSongsByAlbumId(int id)
        {
            throw new NotImplementedException();
        }

        [HttpPost("")]
        public IActionResult CreateNewAlbum()
        {
            throw new NotImplementedException();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAlbum(int id)
        {
            throw new NotImplementedException();
        }
    }
}