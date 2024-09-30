using AudioPool.Models.Dtos;
using AudioPool.Models.Entities;
using AudioPool.Models.InputModels;
using AudioPool.Repository.Contexts;
using AudioPool.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AudioPool.Repository.Implimentations;

public class SongRepository(MusicDbContext context) : ISongRepository
{
    public int CreateNewSong(SongInputModel song)
    {
        var newSong = new Song
        {
            Name = song.Name,
            Duration = song.Duration,
            AlbumId = song.AlbumId
        };

        context.Songs.Add(newSong);
        context.SaveChanges();
        return newSong.Id;
    }

    public bool DeleteSong(int id)
    {
        var song = context.Songs.FirstOrDefault(s => s.Id == id);
        if (song == null) return false;
        context.Songs.Remove(song);
        context.SaveChanges();
        return true;
    }

    public SongDetailsDto? GetSongById(int id)
    {
        var song = context.Songs
            .Include(s => s.Album)
            .ThenInclude(a => a.Songs)
            .FirstOrDefault(s => s.Id == id);


        if (song == null) return null;

        var trackNumber = song.Album.Songs
            .OrderBy(s => s.Id)
            .Select((s, index) => new { s.Id, TrackNumber = index + 1 })
            .FirstOrDefault(s => s.Id == song.Id)?.TrackNumber ?? 0;


        var songDto = new SongDetailsDto
        {
            Id = song.Id,
            Name = song.Name,
            Duration = song.Duration,
            TrackNumberOnAlbum = trackNumber,
            Album = new AlbumDto
            {
                Id = song.Album.Id,
                Name = song.Album.Name,
                ReleaseDate = song.Album.ReleaseDate,
                CoverImageUrl = song.Album.CoverImageUrl,
                Description = song.Album.Description
            }
        };
        return songDto;
    }

    public bool UpdateSong(SongInputModel song, int id)
    {
        var songToUpdate = context.Songs.FirstOrDefault(s => s.Id == id);
        if (songToUpdate == null) return false;
        songToUpdate.Id = id;
        songToUpdate.Name = song.Name;
        songToUpdate.Duration = song.Duration;
        songToUpdate.AlbumId = song.AlbumId;
        context.Songs.Update(songToUpdate);
        context.SaveChanges();
        return true;
    }
}