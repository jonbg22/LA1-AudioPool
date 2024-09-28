using AudioPool.Models;
using AudioPool.Models.Dtos;
using AudioPool.Models.InputModels;
using AudioPool.Services.Interfaces;

namespace AudioPool.Services.Implimentations
{
    public class GenreService : IGenreService
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