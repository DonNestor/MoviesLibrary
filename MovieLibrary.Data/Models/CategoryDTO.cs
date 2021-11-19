using MovieLibrary.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieLibrary.Data.Models
{
    public class CategoryDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public static CategoryDTO CustomerMappCategory(Category category)
        { 
            return new CategoryDTO
            {
                Id = category.Id,
                Name = category.Name
            };
        }
    }
}

