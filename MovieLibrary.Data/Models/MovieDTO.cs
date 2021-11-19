using MovieLibrary.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieLibrary.Data.Models
{
    public class MovieDTO
    {
        public MovieDTO()
        {
            this.MovieCategories = new List<MovieCategoryDTO>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Year { get; set; }
        public decimal ImdbRating { get; set; }

        public CategoryDTO Category { get; set; }

        public virtual ICollection<MovieCategoryDTO> MovieCategories { get; set; }

        public static MovieDTO CustomerMappMovie(Movie movie)
        {
            
            //NEVER ENDING LOOP

            //List<MovieCategoryDTO> MovieCategories = new List<MovieCategoryDTO>();

            //var list = movie.MovieCategories;

            //foreach (var item in list)
            //{
            //    MovieCategories.Add(MovieCategoryDTO.CustomerMappMovieCategory(item));
            //}
           
            return new MovieDTO
            {
                Id = movie.Id,
                Title = movie.Title,
                Description = movie.Description,
                Year = movie.Year,
                //MovieCategories = MovieCategories
            };
        }
    }
}
