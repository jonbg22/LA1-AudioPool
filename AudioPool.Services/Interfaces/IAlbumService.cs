using AudioPool.Models.Dtos;
using AudioPool.Models.InputModels;

namespace AudioPool.Services.Interfaces;

public interface IAlbumService
{
    AlbumDetailsDto GetAlbumById(int id);
    IEnumerable<SongDto> GetSongsByAlbumId(int albumId);
    int CreateNewAlbum(AlbumInputModel album);
    void DeleteAlbum(int id);
}