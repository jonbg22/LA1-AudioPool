using AudioPool.Models.InputModels;
using AudioPool.Services.Interfaces;
using AudioPool.WebApi.Attributes;
using Microsoft.AspNetCore.Mvc;

namespace AudioPool.WebApi.Implimentations;

[ApiController]
[Route("api/songs")]
public class SongController(ISongService songService) : ControllerBase
{
    [HttpGet("")]
    public IActionResult GetSongById(int id)
    {
        var song = songService.GetSongById(id);
        if (song == null) return NotFound();
        return Ok(song);
    }

    [ApiToken]
    [HttpDelete("{id:int}")]
    public IActionResult DeleteSong(int id)
    {
        var songDeleted = songService.DeleteSong(id);
        if (!songDeleted) return NotFound();
        return NoContent();
    }

    [ApiToken]
    [HttpPut("{id:int}")]
    public IActionResult UpdateSong(SongInputModel song, int id)
    {
        var songUpdated = songService.UpdateSong(song, id);
        if (!songUpdated) return NotFound();
        return NoContent();
    }

    [ApiToken]
    [HttpPost("")]
    public IActionResult CreateNewSong(SongInputModel song)
    {
        var id = songService.CreateNewSong(song);
        return CreatedAtAction(nameof(GetSongById), new { id }, null);
    }
}