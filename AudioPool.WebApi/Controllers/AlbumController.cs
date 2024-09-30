using AudioPool.Models.InputModels;
using AudioPool.Services.Interfaces;
using AudioPool.WebApi.Attributes;
using Microsoft.AspNetCore.Mvc;

namespace AudioPool.WebApi.Implimentations
{
    [ApiController]
    [Route("api/albums")]
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
            var album = _albumService.GetAlbumById(id);

            if (album == null)
            {
                return NotFound($"Album with id {id} was not found.");
            }

            return Ok(album);
        }

        [HttpGet("{id}/songs")]
        public IActionResult GetSongsByAlbumId(int id)
        {
            var songs = _albumService.GetSongsByAlbumId(id);

            if (songs == null)
            {
                return NotFound($"Album with id {id} was not found.");
            }

            return Ok(songs);
        }

        [ApiToken]
        [HttpPost("")]
        public IActionResult CreateNewAlbum([FromBody] AlbumInputModel album)
        {
            var newId = _albumService.CreateNewAlbum(album);

            if (newId == null)
            {
                return NotFound("One or more artists with id in 'artistIds' was not found.");
            }

            return CreatedAtRoute("GetAlbumById", new { id = newId }, null);
        }

        [ApiToken]
        [HttpDelete("{id}")]
        public IActionResult DeleteAlbum(int id)
        {
            var success = _albumService.DeleteAlbum(id);

            if (!success)
            {
                return NotFound($"Album with id {id} was not found.");
            }

            return NoContent();
        }
    }
}