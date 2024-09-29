using AudioPool.Models.Dtos;
using AudioPool.Models.InputModels;

namespace AudioPool.Repository.Interfaces;

public interface ISongRepository
{
    SongDetailsDto? GetSongById(int id);
    void DeleteSong(int id);
    void UpdateSong(SongInputModel song, int id);
    int CreateNewSong(SongInputModel song);
}