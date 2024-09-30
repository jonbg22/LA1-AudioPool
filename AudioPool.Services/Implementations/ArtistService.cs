using AudioPool.Models;
using AudioPool.Models.Dtos;
using AudioPool.Models.Entities;
using AudioPool.Models.InputModels;
using AudioPool.Repository.Interfaces;
using AudioPool.Services.Interfaces;

namespace AudioPool.Services.Implimentations
{
    public class ArtistService : IArtistService
    {
        private readonly IArtistRepository _artistRepository;

        public ArtistService(IArtistRepository artistRepository)
        {
            _artistRepository = artistRepository;
        }

        public int CreateNewArtist(ArtistInputModel artist)
        {
            return _artistRepository.CreateNewArtist(artist);
        }

        public Envelope<ArtistDto> GetAllArtist(int pageSize, int pageNumber)
        {
            var artists = _artistRepository.GetAllArtist();

            foreach (ArtistDto a in artists)
            {
                var artistDetails = _artistRepository.GetArtistById(a.Id);
                a.Links.AddReference("self", $"/api/artists/{a.Id}");
                a.Links.AddReference("edit", $"/api/artists/{a.Id}");
                a.Links.AddReference("delete", $"/api/artists/{a.Id}");
                a.Links.AddReference("albums", $"/api/artists/{a.Id}/albums");
        
                a.Links.AddListReference("genres", artistDetails!.Genres.Select(g => $"/api/genres/{g.Id}"));
            }

            Envelope<ArtistDto> envelope = new(pageNumber, pageSize, artists);
            return envelope;
        }

        public ArtistDetailsDto? GetArtistById(int id)
        {
            ArtistDetailsDto? artist = _artistRepository.GetArtistById(id);
            if (artist == null)
            {
                return null;
            }

            artist.Links.AddReference("self", $"/api/artists/{artist.Id}");
            artist.Links.AddReference("edit", $"/api/artists/{artist.Id}");
            artist.Links.AddReference("delete", $"/api/artists/{artist.Id}");
            artist.Links.AddReference("albums", $"/api/artists/{artist.Id}/albums");
            artist.Links.AddListReference("genres", artist.Genres.Select(g => $"/api/genres/{g.Id}"));

            return artist;
        }

        public bool LinkArtistToGenre(int artistId, int genreId)
        {
            var isOk = _artistRepository.LinkArtistToGenre(artistId, genreId);
            return isOk;
        }

        public bool UpdateArtist(int id, ArtistInputModel artist)
        {
            return _artistRepository.UpdateArtist(id, artist);
        }

        public IEnumerable<AlbumDto>? GetArtistAlbums(int id)
        {
            var albums = _artistRepository.GetArtistAlbums(id);
            if (albums == null)
            {
                return null;
            }

            foreach (AlbumDto a in albums)
            {
                IEnumerable<AlbumDto>? artistAlbums = _artistRepository.GetArtistAlbums(a.Id);

                a.Links.AddReference("self", $"/api/albums/{id}");
                a.Links.AddReference("delete", $"/api/albums/{id}");
                a.Links.AddReference("songs", $"/api/albums/{id}");
                if (artistAlbums != null)
                {
                    a.Links.AddListReference("artists", artistAlbums.Select(a => $"/api/artists/{a.Id}"));
                }
                else
                {
                    a.Links.AddListReference("artists", []);
                }
            }

            return albums;
        }


    }
}