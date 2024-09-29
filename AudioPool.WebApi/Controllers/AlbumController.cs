using AudioPool.Models.InputModels;
using AudioPool.Services.Interfaces;
using AudioPool.WebApi.Attributes;
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

        [HttpGet("{id}", Name = "GetAlbumById")]
        public IActionResult GetAlbumById(int id)
        {
            return Ok(_albumService.GetAlbumById(id));
        }

        [HttpGet("{id}/songs")]
        public IActionResult GetSongsByAlbumId(int id)
        {
            return Ok(_albumService.GetSongsByAlbumId(id));
        }

        [ApiToken]
        [HttpPost("")]
        public IActionResult CreateNewAlbum([FromBody] AlbumInputModel album)
        {
            int newId = _albumService.CreateNewAlbum(album);
            return CreatedAtRoute("GetAlbumById", new { id = newId }, null);
        }

        [ApiToken]
        [HttpDelete("{id}")]
        public IActionResult DeleteAlbum(int id)
        {
            _albumService.DeleteAlbum(id);
            return NoContent();
        }
    }
}