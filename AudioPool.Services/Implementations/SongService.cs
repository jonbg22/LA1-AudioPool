using AudioPool.Models;
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
        var song = songRepository.GetSongById(id);
        if (song == null) return null;
        song.Links.AddReference("self", $"/api/songs/{id}");
        song.Links.AddReference("delete", $"/api/songs/{id}");
        song.Links.AddReference("update", $"/api/songs/{id}");
        song.Links.AddReference("album", $"/api/albums/{song.Album.Id}");
        return song;
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