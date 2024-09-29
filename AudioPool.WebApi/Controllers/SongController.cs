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

    [HttpDelete("{id:int}")]
    public IActionResult DeleteSong(int id)
    {
        songService.DeleteSong(id);
        return NoContent();
    }

    [HttpPut("{id:int}")]
    public IActionResult UpdateSong(SongInputModel song, int id)
    {
        songService.UpdateSong(song, id);
        return NoContent();
    }

    [HttpPost("")]
    public IActionResult CreateNewSong(SongInputModel song)
    {
        var id = songService.CreateNewSong(song);
        return CreatedAtAction(nameof(GetSongById), new { id }, null);
    }
}