using Microsoft.EntityFrameworkCore;
using MovieLibrary.Data;
using MovieLibrary.Data.Entities;
using MovieLibrary.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace MovieLibrary.Core.Services
{
    public class MovieService : IMovieService
    {
        private readonly MovieLibraryContext _dbContext;

        public MovieService(MovieLibraryContext dbContext)
        {
            _dbContext = dbContext;
        }

        public MovieDTO GetById(int id)
        {
            var movie = _dbContext.Movies
                .Include(m => m.MovieCategories)
                    .ThenInclude(c => c.Category)
                .FirstOrDefault(m => m.Id == id);

            return MovieDTO.CustomerMappMovie(movie);
        }

        public PageResult<MovieDTO> GetAll(MovieQuery mQuery)
        {
            var baseQuery = _dbContext
                .Movies
                //.Include(m => m.MovieCategories);
                    //.Include(m => m.MovieCategories.Select(c => c.Category))
                    //.ThenInclude(c => c.Category);
                .Where(m => (String.IsNullOrEmpty(mQuery.searchPhrase) && (mQuery.MinImdb == 0 || mQuery.MaxImdb == 0)) 
                       || (m.Title.ToLower().Contains(mQuery.searchPhrase.ToLower()) && (m.ImdbRating >= mQuery.MinImdb && m.ImdbRating <= mQuery.MaxImdb))
                       || (m.Title.ToLower().Contains(mQuery.searchPhrase.ToLower()))
                       || (m.ImdbRating >= mQuery.MinImdb && m.ImdbRating <= mQuery.MaxImdb));

            if (!string.IsNullOrEmpty(mQuery.SortBy))
            {

                var columnsSelector = new Dictionary<string, Expression<Func<Movie, object>>>
                {
                    { nameof(Movie.Title), r => r.Title },
                    { nameof(Movie.Year), r => r.Year },
                    { nameof(Movie.ImdbRating), r => r.ImdbRating },
                };

                //SQLite cannot order by expressions of type 'decimal'.  TO IMPROVE
                var selectedColumn = columnsSelector[mQuery.SortBy];

                baseQuery = mQuery.SortDirection == EnumSortDirection.ASC
                    ? baseQuery.OrderBy(selectedColumn)
                    : baseQuery.OrderByDescending(selectedColumn);
            }

            var movies = baseQuery
               .Skip(mQuery.PageSize * (mQuery.PageNumber - 1))
               .Take(mQuery.PageSize)
               .ToList();

            var totalItemsCount = baseQuery.Count();

            List<MovieDTO> listOfMovies = new List<MovieDTO>();

            foreach (var movie in movies)
            {
                listOfMovies.Add(MovieDTO.CustomerMappMovie(movie));
            }

            var result = new PageResult<MovieDTO>(listOfMovies, totalItemsCount, mQuery.PageSize, mQuery.PageNumber);

            return result;
        }

        public int AddMovie(CreateMovieDTO cMovieDTO)
        {
            Movie movie = new Movie
            {
                Title = cMovieDTO.Title,
                Description = cMovieDTO.Description,
                Year = cMovieDTO.Year,
                ImdbRating = cMovieDTO.ImdbRating,
                //MovieCategories = cMovieDTO.NameCategory
            };

            _dbContext.Movies.Add(movie);
            _dbContext.SaveChanges();

            return movie.Id;
        }


        public bool ChangeMovieById(int id, UpdateMovieDTO updateMovieDTO)
        {
            var movie = _dbContext
               .Movies
               .FirstOrDefault(r => r.Id == id);

            if (movie is null)
            {
                return false;
            }

            movie.Title = updateMovieDTO.Title;
            movie.Description = updateMovieDTO.Description;
            movie.Year = updateMovieDTO.Year;
            movie.ImdbRating = updateMovieDTO.ImdbRating;
            _dbContext.SaveChanges();

            return true;
        }
        public bool DeleteMovie(int id)
        {
            var movie = _dbContext
                .Movies
                .FirstOrDefault(r => r.Id == id);
            if (movie is null)
            {
                return false;
            }

            _dbContext.Movies.Remove(movie);
            _dbContext.SaveChanges();

            return true;
        }
    }
}
