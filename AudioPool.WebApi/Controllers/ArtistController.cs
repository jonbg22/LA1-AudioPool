using AudioPool.Models.InputModels;
using AudioPool.Services.Interfaces;
using AudioPool.WebApi.Attributes;
using Microsoft.AspNetCore.Mvc;

namespace AudioPool.WebApi.Implimentations
{
    [ApiController]
    [Route("/api/artists")]
    public class ArtistController : ControllerBase
    {
        private readonly IArtistService _artistService;

        public ArtistController(IArtistService artistService)
        {
            _artistService = artistService;
        }

        [HttpGet("")]
        public IActionResult GetAllArtists([FromQuery] int pageSize = 25,[FromQuery] int pageNumber = 1)
        {
            return Ok(_artistService.GetAllArtist(pageSize,pageNumber));
        }

        [HttpGet("{id}", Name = "GetArtistById")]
        public IActionResult GetArtistById(int id)
        {
            var artist = _artistService.GetArtistById(id);
            if (artist == null) {
                return NotFound();
            }
            return Ok(artist);
        }

        [HttpGet("{id}/albums")]
        public IActionResult GetArtistAlbums(int id)
        {
            return Ok(_artistService.GetArtistAlbums(id));
        }

        [ApiToken]
        [HttpPost("")]
        public IActionResult CreateNewArtist([FromBody] ArtistInputModel artist)
        {
            var createdId = _artistService.CreateNewArtist(artist);
            return CreatedAtRoute("GetArtistById", new { id = createdId }, null);
        }

        [ApiToken]
        [HttpPut("{artistId}")]
        public IActionResult UpdateArtist(int artistId, [FromBody] ArtistInputModel artist)
        {
            var isOk = _artistService.UpdateArtist(artistId, artist);
            if (!isOk) {
                return NotFound();
            }

            return Ok();
        }
        
        [ApiToken]
        [HttpPatch("{artistId}/genres/{genreId}")]
        public IActionResult LinkArtistToGenre(int artistId, int genreId)
        {
            _artistService.LinkArtistToGenre(artistId, genreId);
            return Ok();
        }
    }
}