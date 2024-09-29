using AudioPool.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AudioPool.WebApi.Implimentations
{
    [ApiController]
    [Route("albums")]
    public class AlbumController : ControllerBase
    {
        private readonly IAlbumService _albumService;

        public AlbumController(IAlbumService albumService)
        {
            _albumService = albumService;
        }

        [HttpGet("{id}")]
        public IActionResult GetAlbumById(int id)
        {
            return Ok(_albumService.GetAlbumById(id));
        }

        [HttpGet("{id}/songs")]
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