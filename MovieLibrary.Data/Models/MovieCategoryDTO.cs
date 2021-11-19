using MovieLibrary.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieLibrary.Data.Models
{
    public class MovieCategoryDTO
    {
        public int MovieId { get; set; }

        public int CategoryId { get; set; }

        public virtual MovieDTO Movie { get; set; }

        public virtual CategoryDTO Category { get; set; }

        public static MovieCategoryDTO CustomerMappMovieCategory(MovieCategory movieCategory)
        {
            return new MovieCategoryDTO 
            {
                MovieId = movieCategory.MovieId,
                CategoryId = movieCategory.CategoryId,
                Movie = MovieDTO.CustomerMappMovie(movieCategory.Movie),
                Category = CategoryDTO.CustomerMappCategory(movieCategory.Category)
            };
        }
    }
}
