using AudioPool.Models.InputModels;
using AudioPool.Services.Interfaces;
using AudioPool.WebApi.Attributes;
using Microsoft.AspNetCore.Mvc;

namespace AudioPool.WebApi.Implimentations;

[ApiController]
[Route("genres")]
public class GenreController(IGenreService genreService) : ControllerBase
{
    private readonly IGenreService _genreService = genreService;

    [HttpGet("")]
    public IActionResult GetAllGenres()
    {
        var genres = _genreService.GetAllGenres();
        return Ok(genres);
    }

    [HttpGet("{id:int}")]
    public IActionResult GetGenreById(int id)
    {
        var genre = _genreService.GetGenreById(id);
        if (genre == null) return NotFound();
        return Ok(genre);
    }

    [ApiToken]
    [HttpPost("")]
    public IActionResult CreateNewGenre(GenreInputModel genreInput)
    {
        var genre = _genreService.CreateNewGenre(genreInput);
        return Ok(genre);
    }
}