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

    public SongDetailsDto? GetSongById(int id)
    {
        return songRepository.GetSongById(id);
    }

    public bool UpdateSong(SongInputModel song, int id)
    {
        return songRepository.UpdateSong(song, id);
    }

    public bool DeleteSong(int id)
    {
        return songRepository.DeleteSong(id);
    }
}