using AudioPool.Models.Dtos;
using AudioPool.Models.InputModels;
using AudioPool.Repository.Interfaces;

namespace AudioPool.Repository.Implimentations
{
    public class AlbumRepository : IAlbumRepository
    {
        public int CreateNewAlbum(AlbumInputModel album)
        {
            throw new NotImplementedException();
        }

        public AlbumDetailsDto GetAlbumById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SongDto> GetSongsByAlbumId(int albumId)
        {
            throw new NotImplementedException();
        }

        public void DeleteAlbum(int id)
        {
            throw new NotImplementedException();
        }

    }
}