using AudioPool.Models.Dtos;
using AudioPool.Models.InputModels;
using AudioPool.Repository.Interfaces;
using AudioPool.Services.Interfaces;

namespace AudioPool.Services.Implimentations;

public class SongService(ISongRepository songRepository) : ISongService
{
    public int CreateNewSong(SongInputModel song)
    {
        return songRepository.CreateNewSong(song);
    }

    public SongDetailsDto GetSongById(int id)
    {
        return songRepository.GetSongById(id);
    }

    public void UpdateSong(SongInputModel song, int id)
    {
        songRepository.UpdateSong(song, id);
    }

    public void DeleteSong(int id)
    {
        songRepository.DeleteSong(id);
    }
}