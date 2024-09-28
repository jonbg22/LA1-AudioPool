using AudioPool.Models.Dtos;
using AudioPool.Models.InputModels;
using AudioPool.Repository.Interfaces;

namespace AudioPool.Repository.Implimentations
{
    public class SongRepository : ISongRepository
    {
        public int CreateNewSong(SongInputModel song)
        {
            throw new NotImplementedException();
        }

        public void DeleteSong(int id)
        {
            throw new NotImplementedException();
        }

        public SongDetailsDto GetSongById(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateSong(SongInputModel song, int id)
        {
            throw new NotImplementedException();
        }
    }
}