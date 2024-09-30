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
            Artist newArtist = new Artist
            {
                Name = artist.Name,
                Bio = artist.Bio,
                CoverImageUrl = artist.CoverImageUrl,
                DateOfStart = artist.DateOfStart,
                DateModified = DateTime.UtcNow,
            };

            _musicDbContext.Artists.Add(newArtist);
            _musicDbContext.SaveChanges();

            return newArtist.Id;
        }

        public IEnumerable<ArtistDto> GetAllArtist()
        {
            var artists = _musicDbContext.Artists
                .OrderByDescending(a => a.DateOfStart)
                .Select(a => new ArtistDto
                {
                    Id = a.Id,
                    Name = a.Name,
                    Bio = a.Bio,
                    CoverImageUrl = a.CoverImageUrl,
                    DateOfStart = a.DateOfStart
                }).ToList();
            return artists;

        }

        public ArtistDetailsDto? GetArtistById(int id)
        {
            var artist = _musicDbContext
            .Artists
            .Include(a => a.Albums)
            .Include(a => a.Genres)
            .FirstOrDefault(a => a.Id == id);

            if (artist == null)
            {
                return null;
            }

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
                }).ToList(),
                Genres = artist.Genres.Select(g => new GenreDto
                {
                    Id = g.Id,
                    Name = g.Name
                }).ToList()
            };
        }

        public IEnumerable<AlbumDto>? GetArtistAlbums(int id)
        {
            var artist = _musicDbContext
            .Artists
            .Include(a => a.Albums)
            .FirstOrDefault(a => a.Id == id);

            if (artist == null)
            {
                return null;
            }

            return artist.Albums.Select(al => new AlbumDto
            {
                Id = al.Id,
                Name = al.Name,
                CoverImageUrl = al.CoverImageUrl,
                Description = al.Description,
                ReleaseDate = al.ReleaseDate
            }).ToList();
        }

        public bool LinkArtistToGenre(int artistId, int genreId)
        {
            var artist = _musicDbContext.Artists.Include(a => a.Genres).FirstOrDefault(a => a.Id == artistId);
            var genre = _musicDbContext.Genres.Include(g => g.Artists).FirstOrDefault(g => g.Id == genreId);

            if (artist == null || genre == null)
            {
                return false;
            }

            if (!artist.Genres.Contains(genre))
            {
                artist.Genres.Add(genre);
            }

            if (!genre.Artists.Contains(artist))
            {
                genre.Artists.Add(artist);
            }

            _musicDbContext.SaveChanges();
            return true;
        }

        public bool UpdateArtist(int id, ArtistInputModel artist)
        {
            var existingArtist = _musicDbContext.Artists.FirstOrDefault(a => a.Id == id);
            if (existingArtist == null)
            {
                return false;
            }

            existingArtist.Bio = artist.Bio;
            existingArtist.CoverImageUrl = artist.CoverImageUrl;
            existingArtist.DateOfStart = artist.DateOfStart;
            existingArtist.DateModified = DateTime.UtcNow;
            existingArtist.Name = artist.Name;

            _musicDbContext.SaveChanges();
            return true;

        }
    }
}