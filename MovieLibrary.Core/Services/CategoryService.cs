using Microsoft.EntityFrameworkCore;
using MovieLibrary.Api.Services;
using MovieLibrary.Data;
using MovieLibrary.Data.Entities;
using MovieLibrary.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MovieLibrary.Core.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly MovieLibraryContext _dbContext;
        public CategoryService(MovieLibraryContext dbContext)
        {
            _dbContext = dbContext;
        }

        public CategoryDTO GetCategoryById(int id)
        {
            var category = _dbContext
                .Categories
                .FirstOrDefault(m => m.Id == id);

            return CategoryDTO.CustomerMappCategory(category);
        }

        public List<CategoryDTO> GetAll()
        {
            var categores = _dbContext.Categories;

            List<CategoryDTO> listOfCategoryDTO = new List<CategoryDTO>();

            foreach (var item in categores)
            {
                listOfCategoryDTO.Add(CategoryDTO.CustomerMappCategory(item));
            }

            return listOfCategoryDTO;
        }

        public int AddCategory(CreateCategoryDTO cCategoryDTO)
        {
            Category category = new Category
            {
                Name = cCategoryDTO.Name
            };

            _dbContext.Categories.Add(category);
            _dbContext.SaveChanges();

            return category.Id;
        }

        public bool ChangeCategoryById(int id, UpdateCategoryDTO uCategoryDTO)
        {
            var category = _dbContext
               .Categories
               .FirstOrDefault(r => r.Id == id);

            if (category is null)
            {
                return false;
            }

            category.Name = uCategoryDTO.Name;
            _dbContext.SaveChanges();

            return true;
        }

        public bool DeleteCategoryById(int id)
        {
            var category = _dbContext
               .Categories
               .FirstOrDefault(r => r.Id == id);
            if (category is null)
            {
                return false;
            }

            _dbContext.Categories.Remove(category);
            _dbContext.SaveChanges();

            return true;
        }
    }
}
