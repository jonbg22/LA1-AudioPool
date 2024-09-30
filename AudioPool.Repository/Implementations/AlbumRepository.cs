using AudioPool.Models.Dtos;
using AudioPool.Models.Entities;
using AudioPool.Models.InputModels;
using AudioPool.Repository.Contexts;
using AudioPool.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AudioPool.Repository.Implimentations
{
    public class AlbumRepository : IAlbumRepository
    {
        private readonly MusicDbContext _dbContext;
        public AlbumRepository(MusicDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public AlbumDetailsDto? GetAlbumById(int id)
        {
            var album = _dbContext
                .Albums
                .Include(al => al.Artists)
                .Include(al => al.Songs)
                .FirstOrDefault(al => al.Id == id);

            if (album == null)
            {
                return null;
            }

            return new AlbumDetailsDto
            {
                Id = album.Id,
                Name = album.Name,
                ReleaseDate = album.ReleaseDate,
                CoverImageUrl = album.CoverImageUrl,
                Description = album.Description,
                Artists = album.Artists.Select(a => new ArtistDto
                {
                    Id = a.Id,
                    Name = a.Name,
                    Bio = a.Bio,
                    CoverImageUrl = a.CoverImageUrl,
                    DateOfStart = a.DateOfStart
                }).ToList(),
                Songs = album.Songs.Select(s => new SongDto
                {
                    Id = s.Id,
                    Name = s.Name,
                    Duration = s.Duration
                }).ToList()

            };
        }

        public IEnumerable<SongDto>? GetSongsByAlbumId(int albumId)
        {
            var album = _dbContext
                .Albums
                .Include(al => al.Songs)
                .FirstOrDefault(a => a.Id == albumId);

            if (album == null)
            {
                return null;
            }

            return album.Songs.Select(s => new SongDto
            {
                Id = s.Id,
                Name = s.Name,
                Duration = s.Duration
            }).ToList();
        }

        public int? CreateNewAlbum(AlbumInputModel albumInputModel)
        {
            Album album = new Album
            {
                Name = albumInputModel.Name,
                ReleaseDate = albumInputModel.ReleaseDate,
                CoverImageUrl = albumInputModel.CoverImageUrl,
                Description = albumInputModel.Description,
                DateModified = DateTime.UtcNow
            };

            _dbContext.Albums.Add(album);
            _dbContext.SaveChanges();

            IEnumerable<int> artistIds = albumInputModel.ArtistIds;

            foreach (int id in artistIds)
            {
                var artist = _dbContext
                    .Artists
                    .FirstOrDefault(a => a.Id == id);

                if (artist == null)
                {
                    return null;
                }

                album.Artists.Add(artist);
                _dbContext.SaveChanges();
            }

            return album.Id;
        }

        public bool DeleteAlbum(int id)
        {
            var album = _dbContext.Albums.FirstOrDefault(al => al.Id == id);

            if (album == null)
            {
                return false;
            }

            _dbContext.Albums.Remove(album);
            _dbContext.SaveChanges();

            return true;
        }

    }
}