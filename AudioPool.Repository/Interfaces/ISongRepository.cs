using AudioPool.Models.Dtos;
using AudioPool.Models.InputModels;

namespace AudioPool.Repository.Interfaces;

public interface ISongRepository
{
    SongDetailsDto? GetSongById(int id);
    bool DeleteSong(int id);
    bool UpdateSong(SongInputModel song, int id);
    int CreateNewSong(SongInputModel song);
}