using AudioPool.Models.Dtos;
using AudioPool.Models.InputModels;

namespace AudioPool.Repository.Interfaces;

public interface IAlbumRepository
{
    AlbumDetailsDto GetAlbumById(int id);
    IEnumerable<SongDto> GetSongsByAlbumId(int albumId);
    int CreateNewAlbum(AlbumInputModel albumInputModel);
    void DeleteAlbum(int id);
}