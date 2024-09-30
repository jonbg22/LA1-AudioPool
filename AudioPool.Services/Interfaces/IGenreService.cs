using AudioPool.Models.Dtos;
using AudioPool.Models.InputModels;

namespace AudioPool.Services.Interfaces;

public interface IGenreService
{
    IEnumerable<GenreDto> GetAllGenres();
    GenreDetailsDto? GetGenreById(int id);
    int CreateNewGenre(GenreInputModel genre);
}