using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MovieLibrary.Data.Models
{
    public class MovieQuery
    {
        public string searchPhrase { get; set; }
        public string  Title { get; set; }
        public decimal MinImdb { get; set; }
        public decimal MaxImdb { get; set; }
        [Required]
        public int PageNumber { get; set; }
        [Required]
        public int PageSize { get; set; }
        public string SortBy { get; set; }
        public EnumSortDirection SortDirection { get; set; }
    }
}
