using AudioPool.Models.InputModels;
using AudioPool.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AudioPool.WebApi.Implimentations;

[ApiController]
[Route("songs")]
public class SongController(ISongService songService) : ControllerBase
{
    [HttpGet("")]
    public IActionResult GetSongById(int id)
    {
        var song = songService.GetSongById(id);
        if (song == null) return NotFound();
        return Ok(song);
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