using AudioPool.Models.Dtos;
using AudioPool.Models.Entities;
using AudioPool.Models.InputModels;
using AudioPool.Repository.Contexts;
using AudioPool.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using GenreDetailsDto = AudioPool.Models.Dtos.GenreDetailsDto;

namespace AudioPool.Repository.Implimentations;

public class GenreRepository(MusicDbContext context) : IGenreRepository
{
    public int CreateNewGenre(GenreInputModel genre)
    {
        var newGenre = new Genre
        {
            Name = genre.Name
        };
        context.Genres.Add(newGenre);
        context.SaveChanges();
        return newGenre.Id;
    }

    public IEnumerable<GenreDto> GetAllGenres()
    {
        var allGenres = context.Genres;
        var genreDtos = allGenres.Select(g => new GenreDto
        {
            Id = g.Id,
            Name = g.Name
        });
        return genreDtos;
    }

    public GenreDetailsDto? GetGenreById(int id)
    {
        var genre = context.Genres
            .Include(g => g.Artists)
            .FirstOrDefault(g => g.Id == id);

        if (genre == null) return null;

        var artistCount = genre.Artists.Count;
        var genreDetailDto = new GenreDetailsDto
        {
            Id = genre.Id,
            Name = genre.Name,
            NumberOfArtists = artistCount
        };
        return genreDetailDto;
    }

    public List<ArtistDto> GetGenreArtists(int genreId)
    {
        var genre = context.Genres
            .Include(g => g.Artists)
            .FirstOrDefault(g => g.Id == genreId);

        if (genre == null) return null;

        var artistDtos = genre.Artists.Select(a => new ArtistDto
        {
            Id = a.Id,
            Name = a.Name
        }).ToList();
        return artistDtos;
    }
}