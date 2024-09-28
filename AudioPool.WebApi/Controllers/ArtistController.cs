using AudioPool.Models.InputModels;
using Microsoft.AspNetCore.Mvc;

namespace AudioPool.WebApi.Implimentations
{
    [ApiController]
    [Route("artists")]
    public class ArtistController : ControllerBase
    {
        [HttpGet("")]
        public IActionResult GetAllArtists()
        {
            throw new NotImplementedException();
        }

        [HttpGet("{id}")]
        public IActionResult GetArtistById(int id)
        {
            throw new NotImplementedException();
        }

        [HttpPost("{id}/albums")]
        public IActionResult GetArtistAlbums(int id)
        {
            throw new NotImplementedException();
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
        [HttpPatch("")]
        public IActionResult LinkArtistToGenre()
        {
            throw new NotImplementedException();
        }
    }
}