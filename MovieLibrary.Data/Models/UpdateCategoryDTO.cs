using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MovieLibrary.Data.Models
{
    public class UpdateCategoryDTO
    {
        [Required]
        [MaxLength(150)]
        public string Name { get; set; }
    }
}
