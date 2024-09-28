using AudioPool.Models.Dtos;
using AudioPool.Models.InputModels;
using AudioPool.Repository.Interfaces;
using AudioPool.Services.Interfaces;

namespace AudioPool.Services.Implimentations;

public class SongService(ISongRepository songRepository) : ISongService
{
    public void CreateNewSong(SongInputModel song)
    {
        throw new NotImplementedException();
    }

    public int DeleteSong(int id)
    {
        throw new NotImplementedException();
    }

    public SongDetailsDto GetSongById(int id)
    {
        return songRepository.GetSongById(id);
    }

    public void UpdateSong(SongInputModel song, int id)
    {
        throw new NotImplementedException();
    }
}