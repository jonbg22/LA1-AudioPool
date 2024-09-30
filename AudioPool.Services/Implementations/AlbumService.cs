using AudioPool.Models;
using AudioPool.Models.Dtos;
using AudioPool.Models.InputModels;
using AudioPool.Repository.Interfaces;
using AudioPool.Services.Interfaces;

namespace AudioPool.Services.Implimentations
{
    public class AlbumService : IAlbumService
    {
        private readonly IAlbumRepository _albumRepository;
        public AlbumService(IAlbumRepository albumRepository)
        {
            _albumRepository = albumRepository;
        }

        public AlbumDetailsDto? GetAlbumById(int albumId)
        {
            var album = _albumRepository.GetAlbumById(albumId);

            if (album == null)
            {
                return null;
            }

            album.Links.AddReference("self", $"/api/albums/{albumId}");
            album.Links.AddReference("delete", $"api/albums/{albumId}");
            album.Links.AddReference("songs", $"api/album/{albumId}/songs");
            album.Links.AddListReference("artists", album.Artists.Select(a => $"/api/artists/{a.Id}"));

            foreach (SongDto s in album.Songs)
            {
                s.Links.AddReference("self", $"/api/songs/{s.Id}");
                s.Links.AddReference("delete", $"api/songs/{s.Id}");
                s.Links.AddReference("update", $"api/songs/{s.Id}");
                s.Links.AddReference("album", $"api/albums/{albumId}");
            }

            return album;
        }

        public IEnumerable<SongDto>? GetSongsByAlbumId(int albumId)
        {
            var songs = _albumRepository.GetSongsByAlbumId(albumId);

            if (songs == null)
            {
                return null;
            }

            foreach (SongDto s in songs)
            {
                s.Links.AddReference("self", $"spi/songs/{s.Id}");
                s.Links.AddReference("delete", $"pai/songs/{s.Id}");
                s.Links.AddReference("edit", $"api/songs/{s.Id}");
                s.Links.AddReference("album", $"api/albums/{albumId}");
            }

            return songs;
        }
        public int? CreateNewAlbum(AlbumInputModel album)
        {
            return _albumRepository.CreateNewAlbum(album);
        }

        public bool DeleteAlbum(int id)
        {
            return _albumRepository.DeleteAlbum(id);
        }

    }
}