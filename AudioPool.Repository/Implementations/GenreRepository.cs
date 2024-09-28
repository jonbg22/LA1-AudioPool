using AudioPool.Models;
using AudioPool.Models.Dtos;
using AudioPool.Models.InputModels;
using AudioPool.Repository.Interfaces;

namespace AudioPool.Repository.Implimentations
{
    public class GenreRepository : IGenreRepository
    {
        public int CreateNewGenre(GenreInputModel artist)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<GenreDto> GetAllGenres()
        {
            throw new NotImplementedException();
        }

        public GenreDetailsDto GetGenreById(int id)
        {
            throw new NotImplementedException();
        }
    }
}