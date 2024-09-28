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
            throw new NotImplementedException();
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