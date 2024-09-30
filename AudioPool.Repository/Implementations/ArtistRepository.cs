using AudioPool.Models.Dtos;
using AudioPool.Models.Entities;
using AudioPool.Models.InputModels;
using AudioPool.Repository.Contexts;
using AudioPool.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AudioPool.Repository.Implimentations
{
    public class ArtistRepository : IArtistRepository
    {
        private readonly MusicDbContext _musicDbContext;

        public ArtistRepository(MusicDbContext musicDbContext)
        {
            _musicDbContext = musicDbContext;
        }

        public int CreateNewArtist(ArtistInputModel artist)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ArtistDto> GetAllArtist()
        {
            return _musicDbContext.Artists.Select(a => new ArtistDto
            {
                Id = a.Id,
                Name = a.Name,
                Bio = a.Bio,
                CoverImageUrl = a.CoverImageUrl,
                DateOfStart = a.DateOfStart
            }).ToList();
        }

        public ArtistDetailsDto GetArtistById(int id)
        {
            var artist = _musicDbContext
            .Artists
            .Include(a => a.Albums)
            .Include(a => a.Genres)
            .FirstOrDefault(a => a.Id == id);

            return new ArtistDetailsDto
            {
                Id = artist.Id,
                Name = artist.Name,
                CoverImageUrl = artist.CoverImageUrl,
                Bio = artist.Bio,
                Albums = artist.Albums.Select(al => new AlbumDto
                {
                    Id = al.Id,
                    Name = al.Name,
                    CoverImageUrl = al.CoverImageUrl,
                    Description = al.Description,
                    ReleaseDate = al.ReleaseDate
                }),
                Genres = artist.Genres.Select(g => new GenreDto
                {
                    Id = g.Id,
                    Name = g.Name
                })
            };
        }

        public IEnumerable<AlbumDto> getArtistAlbums(int id)
        {
            var artist = _musicDbContext
            .Artists
            .Include(a=> a.Albums)
            .FirstOrDefault(a => a.Id == id);
            
            return artist.Albums.Select(al => new AlbumDto
            {
                Id = al.Id,
                Name = al.Name,
                CoverImageUrl = al.CoverImageUrl,
                Description = al.Description,
                ReleaseDate = al.ReleaseDate
            });
        }

        public void LinkArtistToGenre(int artistId, int genreId)
        {
            var artist = _musicDbContext.Artists.FirstOrDefault(a => a.Id == artistId);
            var genre = _musicDbContext.Genres.FirstOrDefault(g => g.Id == genreId);
            var genreEntity = new Genre
            {
                Id = genre.Id,
                DateCreated = genre.DateCreated,
                DateModified = genre.DateModified,
                ModifiedBy = genre.ModifiedBy,
                Artists = genre.Artists
            };
            var artistEntity = new Artist
            {
                Id = artist.Id,
                Bio = artist.Bio,
                CoverImageUrl = artist.CoverImageUrl,
                DateCreated = artist.DateCreated,
                DateModified = artist.DateModified,
                DateOfStart = artist.DateOfStart,
                ModifiedBy = artist.ModifiedBy,
                Albums = artist.Albums,
                Genres = artist.Genres
            };
            genre.Artists.Add(artistEntity);
            artist.Genres.Add(genreEntity);
        }

        public void UpdateArtist(int id, ArtistInputModel artist)
        {
            throw new NotImplementedException();
        }
    }
}