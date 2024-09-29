using AudioPool.Models.Dtos;
using AudioPool.Models.InputModels;

namespace AudioPool.Services.Interfaces;

public interface ISongService
{
    SongDetailsDto? GetSongById(int id);
    bool DeleteSong(int id);
    bool UpdateSong(SongInputModel song, int id);
    int CreateNewSong(SongInputModel song);
}