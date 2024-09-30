using AudioPool.Models.Dtos;
using AudioPool.Models.InputModels;
using AudioPool.Repository.Implimentations;
using AudioPool.Repository.Interfaces;
using AudioPool.Services.Interfaces;

namespace AudioPool.Services.Implimentations
{
    public class AlbumService : IAlbumService
    {
        private readonly IAlbumRepository _albumRepository;
        public AlbumService(IAlbumRepository albumRepository)
        {
            _albumRepository = albumRepository;
        }

        public AlbumDetailsDto GetAlbumById(int id)
        {
            return _albumRepository.GetAlbumById(id);
        }

        public int CreateNewAlbum(AlbumInputModel album)
        {
            return _albumRepository.CreateNewAlbum(album);
        }

        public void DeleteAlbum(int id)
        {
            _albumRepository.DeleteAlbum(id);
        }

        public IEnumerable<SongDto> GetSongsByAlbumId(int albumId)
        {
            return _albumRepository.GetSongsByAlbumId(albumId);
        }
    }
}