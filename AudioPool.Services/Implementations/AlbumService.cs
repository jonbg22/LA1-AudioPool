using AudioPool.Models.Dtos;
using AudioPool.Models.InputModels;
using AudioPool.Services.Interfaces;

namespace AudioPool.Services.Implimentations
{
    public class AlbumService : IAlbumService
    {
        public int CreateNewAlbum(AlbumInputModel album)
        {
            throw new NotImplementedException();
        }

        public int DeleteAlbumById(int id)
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
    }
}