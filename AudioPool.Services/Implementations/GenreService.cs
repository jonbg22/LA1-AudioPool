using AudioPool.Models.Dtos;
using AudioPool.Models.InputModels;
using AudioPool.Repository.Interfaces;
using AudioPool.Services.Interfaces;

namespace AudioPool.Services.Implimentations;

public class GenreService(IGenreRepository genreRepository) : IGenreService
{
    private readonly IGenreRepository _genreRepository = genreRepository;

    public int CreateNewGenre(GenreInputModel genre)
    {
        return _genreRepository.CreateNewGenre(genre);
    }

    public IEnumerable<GenreDto> GetAllGenres()
    {
        return _genreRepository.GetAllGenres();
    }

    public GenreDetailsDto? GetGenreById(int id)
    {
        return _genreRepository.GetGenreById(id);
    }
}