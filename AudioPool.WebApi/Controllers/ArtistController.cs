using AudioPool.Models.InputModels;
using AudioPool.Services.Interfaces;
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
        public IActionResult GetAllArtists()
        {
            return Ok(_artistService.GetAllArtist());
        }

        [HttpGet("{id}")]
        public IActionResult GetArtistById(int id)
        {
            return Ok(_artistService.GetArtistById(id));
        }

        [HttpGet("{id}/albums")]
        public IActionResult GetArtistAlbums(int id)
        {
            return Ok(_artistService.GetArtistAlbums(id));
        }


        [HttpPost("")]
        public IActionResult CreateNewArtist(ArtistInputModel artist)
        {
            throw new NotImplementedException();
        }

        [HttpPut("")]
        public IActionResult UpdateArtist()
        {
            throw new NotImplementedException();
        }

        [HttpPatch("{artistId}/genres/{genreId}")]
        public IActionResult LinkArtistToGenre(int artistId, int genreId)
        {
            _artistService.LinkArtistToGenre(artistId,genreId);
            return Ok();
        }
    }
}