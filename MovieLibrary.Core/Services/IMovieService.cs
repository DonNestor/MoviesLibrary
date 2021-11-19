using MovieLibrary.Data.Entities;
using MovieLibrary.Data.Models;
using System.Collections.Generic;

namespace MovieLibrary.Core.Services
{
    public interface IMovieService
    {
        MovieDTO GetById(int id);

        PageResult<MovieDTO> GetAll(MovieQuery mQuery);

        int AddMovie(CreateMovieDTO cMovieDTO);

        bool ChangeMovieById(int id, UpdateMovieDTO updateMovieDTO);

        bool DeleteMovie(int id);
    }
}