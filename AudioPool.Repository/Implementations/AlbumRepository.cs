using AudioPool.Models.Dtos;
using AudioPool.Models.InputModels;
using AudioPool.Repository.Contexts;
using AudioPool.Repository.Interfaces;

namespace AudioPool.Repository.Implimentations
{
    public class AlbumRepository : IAlbumRepository
    {
        private readonly MusicDbContext _dbContext;
        public AlbumRepository(MusicDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public AlbumDetailsDto GetAlbumById(int id)
        {
            var album = _dbContext
                .Albums
                .FirstOrDefault(al => al.Id == id);

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
                }),
                Songs = album.Songs.Select(s => new SongDto
                {
                    Id = s.Id,
                    Name = s.Name,
                    Duration = s.Duration
                })

            };
        }

        public IEnumerable<SongDto> GetSongsByAlbumId(int albumId)
        {
            throw new NotImplementedException();
        }

        public int CreateNewAlbum(AlbumInputModel album)
        {
            throw new NotImplementedException();
        }

        public void DeleteAlbum(int id)
        {
            throw new NotImplementedException();
        }

    }
}