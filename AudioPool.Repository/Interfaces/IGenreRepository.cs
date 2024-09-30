using AudioPool.Models.Dtos;
using AudioPool.Models.InputModels;

namespace AudioPool.Repository.Interfaces;

public interface IGenreRepository
{
    IEnumerable<GenreDto> GetAllGenres();
    GenreDetailsDto? GetGenreById(int id);
    int CreateNewGenre(GenreInputModel genre);
    List<ArtistDto> GetGenreArtists(int genreId);
}