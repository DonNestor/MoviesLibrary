using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MovieLibrary.Data.Models
{
    public class CreateMovieDTO
    {
       
        [MaxLength(150)]
        public string Title { get; set; }
     
        [MaxLength(500)]
        public string Description { get; set; }
        
        [Required]
        public int Year { get; set; }
        
        [Required]
        public decimal ImdbRating { get; set; }

        public string NameCategory { get; set; }
    }
}
