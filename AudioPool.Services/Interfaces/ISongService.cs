using AudioPool.Models.Dtos;
using AudioPool.Models.InputModels;

namespace AudioPool.Services.Interfaces
{
    public interface ISongService
    {
        SongDetailsDto GetSongById(int id);
        int DeleteSong(int id);
        void UpdateSong(SongInputModel song, int id);
        void CreateNewSong(SongInputModel song);
    }
}