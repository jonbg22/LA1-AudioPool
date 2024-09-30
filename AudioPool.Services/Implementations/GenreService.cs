using AudioPool.Models;
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
        var genres = _genreRepository.GetAllGenres();
        var genreDtos = genres as GenreDto[] ?? genres.ToArray();
        foreach (var genre in genreDtos)
        {
            genre.Links.AddReference("self", $"/api/genres/{genre.Id}");
            var artists = _genreRepository.GetGenreArtists(genre.Id);
            if (artists != null) genre.Links.AddListReference("artists", artists.Select(a => $"/api/artists/{a.Id}"));
        }

        return genreDtos;
    }

    public GenreDetailsDto? GetGenreById(int id)
    {
        var genre = _genreRepository.GetGenreById(id);
        if (genre == null) return null;
        genre.Links.AddReference("self", $"/api/genres/{id}");
        var artists = _genreRepository.GetGenreArtists(id);
        if (artists != null) genre.Links.AddListReference("artists", artists.Select(a => $"/api/artists/{a.Id}"));
        return genre;
    }
}